using Rex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Math
{
    public class Not : Command
    {
        public override string Key => "~";

        public override string Do(string line)
        {
            return (line == "0").ToInt().ToString();
        }
    }
}
