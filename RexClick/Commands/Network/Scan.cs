using Rex.Core;

namespace Rex.Commands.Network
{
    public class Scan : Command
    {
        public override string Key => "scan";

        public override string Do(string line)
        {
            return Server.instance.TryPort().ToInt().ToString();
        }
    }
}
