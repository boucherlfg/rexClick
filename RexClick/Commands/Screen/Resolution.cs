namespace Rex.Commands.Screen
{
    public class Resolution : Command
    {
        public Resolution()
        {
        }

        public override string Key => "resolution";

        public override string Do(string line)
        {
            var screen = System.Windows.Forms.Screen.PrimaryScreen;
            if (line.ToLower() == "x")
                return screen.Bounds.Width.ToString();
            else if (line.ToLower() == "y")
                return screen.Bounds.Height.ToString();
            else
                return screen.Bounds.Width + " " + screen.Bounds.Height;
        }
    }
}