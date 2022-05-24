using Rex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Consoles
{
    public class Show : Command
    {
        public override string Key => "show";

        public override string Do(string line)
        {
            switch (line.ToBool())
            {
                case false:
                    Hooks.Screen.HideWindow();
                    break;
                case true:
                    Hooks.Screen.ShowWindow();
                    break;
            }
            return "";
        }
    }
}
