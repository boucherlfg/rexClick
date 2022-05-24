using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Screen
{
    public class ScreenCommand : CompositeCommand
    {
        public override string Key => "screen";
        public ScreenCommand() : base(new Get(), new Set(), new Resolution(), new Pixel(), new Help()) { }
    }
}
