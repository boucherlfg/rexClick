using Rex.Core;

namespace Rex.Commands.Network
{
    public class Port : Command
    {
        public override string Key => "port";

        public override string Do(string line)
        {
            Config.instance.port = line.ToInt();
            return "";
        }
    }
}
