using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Consoles
{
    public class Ask : Command
    {
        public override string Key => "ask";

        public override string Do(string line)
        {
            return System.Console.ReadLine();
        }
    }
}
