using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands
{
    public abstract class Command
    {
        public abstract string Key { get; }
        public abstract string Do(string line);
    }
}
