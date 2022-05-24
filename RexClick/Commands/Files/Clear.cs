using Rex.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Files
{
    public class Clear : Command
    {
        public override string Key => "clear";

        public override string Do(string line)
        {
            File.WriteAllText(Config.instance.path + "\\" + line.Replace("/", "\\"), "", Encoding.UTF8);
            return "";
        }
    }
}
