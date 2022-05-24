using Rex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Network
{
    public class Info : Command
    {
        public override string Key => "info";

        public override string Do(string line)
        {
            if (line == "ip") return Config.instance.ipAddress.ToString();
            else if (line == "port") return Config.instance.port.ToString();
            else return Config.instance.ipAddress + " " + Config.instance.port;
        }
    }
}
