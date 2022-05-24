using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Path
{
    public class PathCommand : CompositeCommand
    {
        public override string Key => "path";
        public PathCommand() : base(new Add(), new Del(), new Exist(), new Find(), new Goto(), new List(), new Help()) { }
    }
}
