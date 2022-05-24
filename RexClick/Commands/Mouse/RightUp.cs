using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Mouse
{
    public class RightUp : Command
    {
        public override string Key => "rightup";

        public override string Do(string line)
        {
            Hooks.Mouse.RightUp();
            return "";
        }
    }
}
