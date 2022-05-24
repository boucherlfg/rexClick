
using Rex.Core;

namespace Rex.Commands.Network
{
    public class Ping : Command
    {
        public override string Key => "ping";

        public override string Do(string line)
        {
            return Server.instance.MakePing().ToInt().ToString();
        }
    }
}
