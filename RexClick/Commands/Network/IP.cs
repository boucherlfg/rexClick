using System.Net;
using Rex.Core;

namespace Rex.Commands.Network
{
    public class IP : Command
    {
        public override string Key => "ip";

        public override string Do(string line)
        {
            if (!IPAddress.TryParse(line, out var dummy)) return "";
            Config.instance.ipAddress = line;
            return "";
        }
    }
}
