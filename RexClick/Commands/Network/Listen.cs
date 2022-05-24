using Rex.Core;

namespace Rex.Commands.Network
{
    public class Listen : Command
    {
        public override string Key => "listen";

        public override string Do(string line)
        {
            if (line.ToBool())
            {
                Server.instance.StartListen();
            }
            else
            {
                Server.instance.StopListen();
            }
            return "";
        }
    }
}
