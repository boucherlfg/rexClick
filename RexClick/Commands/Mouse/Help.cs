namespace Rex.Commands.Mouse
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- block <1|0> : lets you set if the mouse works or not
- set <x pixel> <y pixel>: sets the cursor's actual position
- last : lets the user know the last button action of the mouse
- leftdown: puts the left button down
- leftup: puts the left button up
- rightdown: puts the right button down
- rightup: puts the right button up
- pos <x|y>: gives the cursor's actual position";
        }
    }
}