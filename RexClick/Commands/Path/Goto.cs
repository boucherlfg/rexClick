using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rex.Core;

namespace Rex.Commands.Path
{
    public class Goto : Command
    {
        public override string Key => "cd";

        public override string Do(string line)
        {
            if (line == "..")
                Config.instance.path = Directory.GetParent(Config.instance.path).FullName;
            else if (Directory.Exists(Config.instance.path + "\\" + line))
                Config.instance.path = Config.instance.path + "\\" + line;
            else
            {
                string[] remain = Directory.GetDirectories(Config.instance.path);
                foreach (string bit in Config.instance.path.Split('*'))
                {
                    remain = remain.ToList().FindAll(x => x.Contains(bit)).ToArray();
                }
                if (remain.Length != 0)
                    Config.instance.path = Config.instance.path + "\\" + remain[0];
            }
            return "";
        }
    }
}
