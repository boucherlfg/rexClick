using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Mouse
{
    public class MouseCommand : CompositeCommand
    {
        public override string Key => "mouse";

        public MouseCommand() : base(
            new Last(), 
            new LeftDown(), 
            new LeftUp(), 
            new Pos(), 
            new RightDown(), 
            new RightUp(), 
            new Set(), 
            new Block(), 
            new Help()) { }
    }
}
