using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Console
{
    public class Back : Command
    {
        public override string Key => "back";

        public override string Do(string line)
        {
            var color = Enum.GetValues(typeof(ConsoleColor)).OfType<ConsoleColor>().FirstOrDefault(x => x.ToString() == line);
            System.Console.BackgroundColor = color;
            return "";
        }
    }
}
