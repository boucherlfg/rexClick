using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rex.Core;

namespace Rex.Commands.Network
{
    public class Send : Command
    {
        public override string Key => "send";

        public override string Do(string line)
        {
            Server.instance.Send(line);
            return "";
        }
    }
}
