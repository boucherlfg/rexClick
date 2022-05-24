using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Application
{
    public class Exit : Command
    {
        public override string Key => "exit";

        public override string Do(string line)
        {
            Environment.Exit(0);
            return "";
        }
    }
}
