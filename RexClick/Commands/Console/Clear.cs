using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Consoles
{
    public class Clear : Command
    {
        public override string Key => "clear";

        public override string Do(string line)
        {
            System.Console.Clear();
            return "";
        }
    }
}
