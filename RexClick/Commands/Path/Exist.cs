using Rex.Core;

namespace Rex.Commands.Path
{
    public class Exist : Command
    {
        public override string Key => "exist";

        public override string Do(string line)
        {
            var path = System.IO.Path.Combine(Config.instance.path, line.Replace("/", "\\"));
            var exist = System.IO.File.Exists(path);
            exist |= System.IO.Directory.Exists(path);
            return exist.ToInt().ToString();
        }
    }
}
