using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- app : all things relative to rex
- clip : clipboard commands
- console : relative to printing and reading from console
- file : relative to file management
- key : relative to the keyboard
- mouse : relative to the mouse cursor
- net : relative to network management and communication
- path : relative to file system management
- screen : relative to monitors
- var : manage application variables";
        }
    }
}
