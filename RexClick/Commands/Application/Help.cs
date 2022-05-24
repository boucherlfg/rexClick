using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Application
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- wait <time in ms>: waits a certain time
- run <filename> <arguments> : lets you use a script instead of typing the commands
- exe <filename> <arguments>: lets you run an external executable.
- exit : closes the application";
        }
    }
}
