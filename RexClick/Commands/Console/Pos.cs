using Rex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Console
{
    public class Pos : Command
    {
        public override string Key => "pos";

        public override string Do(string line)
        {
            int x = line.Split(' ').First().ToInt();
            int y = line.Split(' ').Skip(1).First().ToInt();
            System.Console.SetCursorPosition(x, y);
            return "";
        }
    }
}
