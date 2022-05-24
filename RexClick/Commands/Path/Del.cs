using Rex.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Path
{
    public class Del : Command
    {
        public override string Key => "del";

        public override string Do(string line)
        {
            var path = System.IO.Path.Combine(Config.instance.path, line.Replace("/", "\\"));
            if (!Directory.Exists(line)) return "";
            Directory.Delete(path);
            return "";
        }
    }
}
