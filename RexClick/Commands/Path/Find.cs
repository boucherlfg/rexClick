using Rex.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Path
{
    public class Find : Command
    {
        public override string Key => "find";

        public override string Do(string line)
        {
            string ret = "";
            string path = Config.instance.path;
            foreach (string dir in Directory.GetDirectories(path, "*", SearchOption.AllDirectories))
            {
                if (dir.Contains(line))
                    ret += "directory: " + dir + "\n";
}
            foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
            {
                if (file.Contains(line))
                    ret += "file: " + file + "\n";
            }
            return ret;
        }
    }
}
