using Rex.Commands.Keyboard;
using Rex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Mouse
{
    public class Block : Command
    {
        public override string Key => "block";

        public override string Do(string line)
        {
            Hooks.Mouse.block = line.ToBool();
            return "";
        }
    }
}
