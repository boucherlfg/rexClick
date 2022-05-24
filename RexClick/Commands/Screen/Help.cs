namespace Rex.Commands.Screen
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- resolution <x|y> : get the resolution of the screen.
- pixel <x> <y> <param> : get the color / ARGB component of a given pixel.
- set <1|0> : turn on or off the monitor.
- get : how many monitors are active";
        }
    }
}