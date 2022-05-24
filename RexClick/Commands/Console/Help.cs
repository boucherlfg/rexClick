using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Consoles
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- help : lets you see all the commands and their use
- clearcon : lets you clear the console window
- print <text> : permet d'écrire sur la console
- ask : permet de demander une entrée de la console
- window <hide/show> : lets you hide or show the console window";
        }
    }
}
