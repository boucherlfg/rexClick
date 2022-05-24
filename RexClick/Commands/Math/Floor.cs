using Rex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Math
{
    public class Floor : Command
    {
        public override string Key => "_";

        public override string Do(string line)
        {
            return line.ToFloat().ToInt().ToString();
        }
    }
}
