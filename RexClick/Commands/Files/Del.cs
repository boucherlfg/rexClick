using Rex.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Files
{
    public class Del : Command
    {
        public override string Key => "del";

        public override string Do(string line)
        {
            File.Delete(Config.instance.path + "\\" + line.Replace("/", "\\"));
            return "";
        }
    }
}
