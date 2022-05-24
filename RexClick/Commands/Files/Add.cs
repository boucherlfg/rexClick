using Rex.Core;
using System.IO;
using System.Linq;
namespace Rex.Commands.Files
{
    public class Add : Command
    {
        public override string Key => "add";

        public override string Do(string line)
        {
            line = line.Replace("/", "\\");
            var file = System.IO.Path.Combine(Config.instance.path, line);
            
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(file)))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(file));
            }
            if (File.Exists(file)) return "";
            File.Create(file).Close();
            return "";
        }
    }
}
