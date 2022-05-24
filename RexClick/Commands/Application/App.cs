using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Application
{
    public class App : CompositeCommand
    {
        public override string Key => "app";
        public App() : base(new Exe(), new Exit(), new Run(), new Wait(), new Help(), new Time(), new Eval()) { }
    }
}
