using Rex.Core;

namespace Rex.Commands.Screen
{
    public class Set : Command
    {
        public override string Key => "set";

        public override string Do(string line)
        {
            Hooks.Screen.SetMonitorState(line.ToBool());
            return "";
        }
    }
}
