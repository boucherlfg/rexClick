using Rex.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Files
{
    public class Write : Command
    {
        public override string Key => "write";

        public override string Do(string line)
        {
            string path = Config.instance.path + "\\" + line.Split(' ').First().Replace("/", "\\");
            string content = string.Join(" ", line.Split(' ').Skip(1));
            File.WriteAllText(path, content, Encoding.UTF8);
            return "";
        }
    }
}
