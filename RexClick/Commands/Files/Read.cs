using Rex.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Files
{
    public class Read : Command
    {
        public override string Key => "read";

        public override string Do(string line)
        {
            string path = Config.instance.path + "\\" + line.Replace("/", "\\");
            return File.ReadAllText(path, Encoding.UTF8);
        }
    }
}
