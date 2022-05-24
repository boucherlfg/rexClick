using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Mouse
{
    public class Last : Command
    {
        public override string Key => "last";

        public override string Do(string line)
        {
            return Hooks.Mouse.now.ToString();
        }
    }
}
