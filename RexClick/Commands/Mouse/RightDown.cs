using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Mouse
{
    public class RightDown : Command
    {
        public override string Key => "rightdown";

        public override string Do(string line)
        {
            Hooks.Mouse.RightDown();
            return "";
        }
    }
}
