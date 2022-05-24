using Rex.Core;
using System.Linq;

namespace Rex.Commands.Variables
{
    public class Set : Command
    {
        public override string Key => "set";

        public override string Do(string line)
        {
            string name = line.Split(' ').First();
            string value = string.Join(" ", line.Split(' ').Skip(1));
            Data.Instance[name] = value;
            return "";
        }
    }
}
