using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Variables
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- set <variable> <value> : lets you set a variable to a given value
- del <variable> : deletes a variable from the variable register
- get <variable> : returns the value contained by the given variable
- has <variable> : does given variable exist?";
        }
    }
}
