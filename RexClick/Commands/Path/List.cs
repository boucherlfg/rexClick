using Rex.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Path
{
    public class List : Command
    {
        public override string Key => "ls";

        public override string Do(string line)
        {
            return string.Join(" ", Directory.GetFiles(Config.instance.path).Select(x => System.IO.Path.GetFileName(x)).Where(x => x.Contains(line)));
        }
    }
}
