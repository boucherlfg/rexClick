using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Variables
{
    public class Var : CompositeCommand
    {
        public override string Key => "var";
        public Var() : base(new Set(), new Get(), new Has(), new Help(), new Del()) { }
    }
}
