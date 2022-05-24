using Rex.Core;

namespace Rex.Commands.Keyboard
{
    public class State : Command
    {
        public override string Key => "state";

        public override string Do(string line)
        {
            return Hooks.Keyboard.KeyState(line).ToInt().ToString();
        }
    }
}