using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Consoles
{
    public class Print : Command
    {
        public override string Key => "print";

        public override string Do(string line)
        {
            System.Console.WriteLine(line);
            return "";
        }
    }
}
