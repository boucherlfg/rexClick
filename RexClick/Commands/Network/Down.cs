using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rex.Core;
namespace Rex.Commands.Network
{
    public class Down : Command
    {
        public override string Key => "down";

        public override string Do(string line)
        {
            Server.instance.ClientDownload(line);
            return "";
        }
    }
}
