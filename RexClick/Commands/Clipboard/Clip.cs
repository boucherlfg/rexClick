using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Clipboard
{
    public class Clip : CompositeCommand
    {
        public override string Key => "clip";

        public Clip() : base(new Get(), new Set(), new Help()) { }
    }
}
