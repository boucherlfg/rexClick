using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Math
{
    public class MathCommand : CompositeCommand
    {
        public override string Key => "";
        public MathCommand() : base(new Add(), new Div(), new Eq(), 
            new Floor(), new Leq(), new Les(), new Meq(), new Mor(), 
            new Mult(), new Neq(), new Not(), new Pow(), new Rand(), new Sub()) { }
    }
}
