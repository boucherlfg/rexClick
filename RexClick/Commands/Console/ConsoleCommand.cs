using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Console
{
    public class ConsoleCommand : CompositeCommand
    {
        public ConsoleCommand() : base(new Ask(), new Clear(), new Help(), new Print(), new Show(), new Help(), new Back(), new Fore(), new Pos()) { }
        public override string Key => "console";
    }
}
