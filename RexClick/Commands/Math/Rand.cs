using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Math
{
    public class Rand : Command
    {
        private static Random rand = new Random();

        public override string Key => "rand";

        public override string Do(string line)
        {
            return rand.NextDouble().ToString();
        }
    }
}
