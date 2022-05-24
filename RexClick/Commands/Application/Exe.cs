using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Application
{
    public class Exe : Command
    {
        public override string Key => "exe";

        public override string Do(string line)
        {
            return new Rex.Script().Execute(line);
        }
    }
}
