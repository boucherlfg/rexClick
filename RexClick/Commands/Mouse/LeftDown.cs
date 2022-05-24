using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Mouse
{
    public class LeftDown : Command
    {
        public override string Key => "leftdown";

        public override string Do(string line)
        {
            Hooks.Mouse.LeftDown();
            return "";
        }
    }
}
