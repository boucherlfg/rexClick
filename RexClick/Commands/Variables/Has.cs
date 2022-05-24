using Rex.Core;

namespace Rex.Commands.Variables
{
    public class Has : Command
    {
        public override string Key => "has";

        public override string Do(string line)
        {
            return Data.Instance.Has(line).ToInt().ToString();
        }
    }
}
