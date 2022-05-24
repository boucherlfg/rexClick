using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Application
{
    public class Run : Command
    {
        public override string Key => "run";

        public override string Do(string line)
        {
            return new Script().Run(line);
        }
    }
}
