namespace Rex.Commands.Keyboard
{
    public class Last : Command
    {
        public override string Key => "last";

        public override string Do(string line)
        {
            return Hooks.Keyboard.now.ToString();
        }
    }
}