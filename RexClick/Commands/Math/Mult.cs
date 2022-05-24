using Rex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Math
{
    public class Mult : Command
    {
        public override string Key => "*";

        public override string Do(string line)
        {
            var a = line.Split(' ').First();
            var b = string.Join(" ", line.Split(' ').Skip(1));
            return (a.ToFloat() * b.ToFloat()).ToString();
        }
    }
}
