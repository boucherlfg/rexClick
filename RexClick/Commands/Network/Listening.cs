using Rex.Core;

namespace Rex.Commands.Network
{
    public class Listening : Command
    {
        public override string Key => "listening";

        public override string Do(string line)
        {
            return Data.Instance.listening.ToInt().ToString();
        }
    }
}
