using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Keyboard
{
    public class KeyCommand : CompositeCommand
    {
        public override string Key => "key";
        public KeyCommand() : base(new Block(), new Stroke(), new Last(), new State(), new Help()) { }
    }
}
