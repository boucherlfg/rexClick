using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Consoles
{
    public class Console : CompositeCommand
    {
        public Console() : base(new Ask(), new Clear(), new Help(), new Print(), new Show(), new Help()) { }
        public override string Key => "console";
    }
}
