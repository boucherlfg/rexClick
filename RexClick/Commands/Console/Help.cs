using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Console
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
- fore <color> : permet de changer la couleur du texte sur la console
- back <color> : permet de changer la couleur d'arrière plan du texte sur la console
- pos <x> <y> : permet de changer la position du curseur dans la console
- window <hide/show> : lets you hide or show the console window";
        }
    }
}
