using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands
{
    public abstract class CompositeCommand : Command, IEnumerable<Command>
    {
        protected List<Command> commands;

        public CompositeCommand(params Command[] commands) { this.commands = new List<Command>(commands); }

        public override string Do(string line)
        {
            string sw = line.Split(' ').First();
            string arg = string.Join(" ", line.Split(' ').Skip(1));
            var com = commands.Find(x => x.Key == sw);
            if (com != null) return com.Do(arg);
            else throw new Exception($"command {sw} doesn't exist");
        }

        public IEnumerator<Command> GetEnumerator()
        {
            return commands.GetEnumerator();
        }

        public bool IsValid(string line)
        {
            var key = line.Split(' ').First();
            return commands.Exists(x => x.Key == key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return commands.GetEnumerator();
        }
    }
}
