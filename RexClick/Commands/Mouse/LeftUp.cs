using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Mouse
{
    public class LeftUp : Command
    {
        public override string Key => "leftup";

        public override string Do(string line)
        {
            Hooks.Mouse.LeftUp();
            return "";
        }
    }
}
