using Rex.Core;

namespace Rex.Commands.Keyboard
{
    public class Block : Command
    {
        public override string Key => "block";

        public override string Do(string line)
        {
            Hooks.Keyboard.block = line.ToBool();
            return "";
        }
    }
}