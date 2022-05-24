using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Network
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- config : shows the network informations of the application
- localip : return the local ip address of the computer
- ip <ip address> : sets the ip addres to given value
- port <port number> : sets the tcp port to given value
- listen <start|stop> : start a tcp listener on given ip address and port
- listening : is the application's server currently up?
- send <message>: posts a command onto the given tcp address and port
- down <filename> : lets you download a file from a remote location
- up <filename> : lets you upload a file to a remote location
- ping : sends a ECHO message to given ip address
- scan : attempt to test connection to a TCP port at a given address";
        }
    }
}
