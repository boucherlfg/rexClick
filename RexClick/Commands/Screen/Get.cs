using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Screen
{
    public class Get : Command
    {
        public override string Key => "get";

        public override string Do(string line)
        {
            return Hooks.Screen.MonitorCount.ToString();
        }
    }
}
