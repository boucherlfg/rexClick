using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Path
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- add <name> : creates a folder at current path
- del <name> : delete given folder at current path
- list : lets you see the content of your current path
- find <pattern> : lets you search recursively for a given pattern in a filename
- goto <target> : change the directory path you are at
- path : returns the current path you are at
- exist <name> : tels if a given file or directory exists in current path";
        }
    }
}
