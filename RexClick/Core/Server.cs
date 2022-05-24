using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace Rex.Core
{
    public class Config
    {
        public static Config instance = new Config();
        private Config()
        {
            ipAddress = "127.0.0.1";
            port = 5000;
            path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
        }
        public string ipAddress;
        public int port;
        public string path;
    }
    public class Server
    {
        public static Server instance = new Server();
        private Thread thread;
        private bool listening;
        public bool Running => listening;

        public void StartListen()
        {
            thread = new Thread(new ThreadStart(() => Listen()));
            thread.Start();
            listening = true;
        }
        public void StopListen() => listening = false;
        private void Listen()
        {
            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(Config.instance.ipAddress);
            TcpListener listener = new TcpListener(localAdd, Config.instance.port);
            byte[] buffer;
            int bytesRead;
            string dataReceived;

            while (listening)
            {
                listener.Start();

                //---incoming client connected---
                using (TcpClient client = listener.AcceptTcpClient())
                {
                    //---get the incoming data through a network stream---
                    using (NetworkStream nwStream = client.GetStream())
                    {
                        buffer = new byte[client.ReceiveBufferSize];

                        //---read incoming stream---
                        bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                        //---convert the data received into a string---
                        dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        try
                        {
                            //si on recoit une demande "sendme", on n'exécute pas "command": on mets dans le buffer le contenu de la demande
                            if (dataReceived.StartsWith("sendme"))
                            {
                                if (File.Exists(Config.instance.path + "\\" + dataReceived.Split(' ').Skip(1).Join(" ")))
                                {
                                    buffer = File.ReadAllBytes(Config.instance.path + "\\" + dataReceived.Split(' ').Skip(1).Join(" "));
                                    SendData(buffer, nwStream);
                                    //the file writing here is made because i seem to lose my files content with the file.readallbytes function
                                    File.WriteAllBytes(Config.instance.path + "\\" + dataReceived.Split(' ').Skip(1).Join(" "), buffer);
                                }
                            }
                            else if (dataReceived.StartsWith("sending"))
                            {
                                File.WriteAllBytes(Config.instance.path + "\\" + dataReceived.Split(' ').Skip(1).Join(" "), GetData(client, nwStream));
                            }
                            else if (dataReceived.StartsWith("message"))
                            {
                                Console.WriteLine(Rex.Script.ResolveLine(dataReceived.Split(' ').Skip(1).Join(" ")));
                            }
                            else
                            {
                                dataReceived = Rex.Script.ResolveLine(dataReceived);
                                buffer = Encoding.UTF8.GetBytes(dataReceived);
                                nwStream.Write(buffer, 0, buffer.Length);
                            }
                        }
                        catch (Exception e)
                        {
                            dataReceived = e.Message;
                            buffer = Encoding.UTF8.GetBytes(dataReceived);
                            nwStream.Write(buffer, 0, buffer.Length);
                        }


                        client.Close();
                        listener.Stop();
                    }
                }
            }
        }

        //https://stackoverflow.com/questions/9963052/sending-a-file-using-tcpclient-and-networkstream-in-c-sharp
        //miraculously well-working
        static void SendData(byte[] data, NetworkStream stream)
        {
            int bufferSize = 1024;

            byte[] dataLength = BitConverter.GetBytes(data.Length);

            stream.Write(dataLength, 0, 4);

            int bytesSent = 0;
            int bytesLeft = data.Length;

            while (bytesLeft > 0)
            {
                int curDataSize = System.Math.Min(bufferSize, bytesLeft);

                stream.Write(data, bytesSent, curDataSize);

                bytesSent += curDataSize;
                bytesLeft -= curDataSize;
            }
        }
        static byte[] GetData(TcpClient client, NetworkStream stream)
        {
            byte[] fileSizeBytes = new byte[4];
            int bytes = stream.Read(fileSizeBytes, 0, 4);
            //get la taille du fichier à venir
            int dataLength = BitConverter.ToInt32(fileSizeBytes, 0);

            int bytesLeft = dataLength;
            byte[] data = new byte[dataLength];

            int bufferSize = 1024;
            int bytesRead = 0;

            while (bytesLeft > 0)
            {
                //vérifier / actualiser la taille actuelle du buffer
                int curDataSize = System.Math.Min(bufferSize, bytesLeft);
                if (client.Available < curDataSize)
                    curDataSize = client.Available;

                //ajouter à "data" la suite du message
                bytes = stream.Read(data, bytesRead, curDataSize);

                bytesRead += curDataSize;
                bytesLeft -= curDataSize;
            }

            return data;
        }

        public void ClientDownload(string file)
        {
            //---create a TCPClient object at the IP and port no.---
            using (TcpClient client = new TcpClient(Config.instance.ipAddress, Config.instance.port))
            {
                using (NetworkStream nwStream = client.GetStream())
                {
                    //send the query
                    byte[] buffer = Encoding.UTF8.GetBytes("sendme " + file);
                    nwStream.Write(buffer, 0, buffer.Length);

                    buffer = GetData(client, nwStream);

                    client.Close();
                    File.WriteAllBytes(file, buffer);
                }
            }
        }
        public void ClientUpload(string file)
        {
            //---create a TCPClient object at the IP and port no.---
            using (TcpClient client = new TcpClient(Config.instance.ipAddress, Config.instance.port))
            {
                using (NetworkStream nwStream = client.GetStream())
                {
                    //send the query
                    byte[] buffer = Encoding.UTF8.GetBytes("sending " + file);
                    nwStream.Write(buffer, 0, buffer.Length);

                    buffer = File.ReadAllBytes(Config.instance.path + "\\" + file);
                    SendData(buffer, nwStream);

                    client.Close();
                    File.WriteAllBytes(Config.instance.path + "\\" + file, buffer);
                }
            }
        }
        public bool TryPort()
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(Config.instance.ipAddress, Config.instance.port);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool MakePing()
        {
            PingReply reply = new Ping().Send(IPAddress.Parse(Config.instance.ipAddress));
            return reply.Status == IPStatus.Success;
        }
        public string Send(string textToSend)
        {
            //---create a TCPClient object at the IP and port no.---
            using (TcpClient client = new TcpClient(Config.instance.ipAddress, Config.instance.port))
            {
                using (NetworkStream nwStream = client.GetStream())
                {
                    byte[] bytesToSend = Encoding.UTF8.GetBytes(textToSend);

                    //---send the text---
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                    //---read back the text---
                    bytesToSend = new byte[client.ReceiveBufferSize];
                    int bytesRead = nwStream.Read(bytesToSend, 0, client.ReceiveBufferSize);
                    textToSend = Encoding.UTF8.GetString(bytesToSend, 0, bytesRead);
                    client.Close();
                }
            }
            return textToSend;
        }
    }
}