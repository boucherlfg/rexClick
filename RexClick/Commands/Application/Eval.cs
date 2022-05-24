using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Application
{
    public class Eval : Command
    {
        public override string Key => "eval";

        public override string Do(string line)
        {
            return Script.ResolveLine(line);
        }
    }
}
