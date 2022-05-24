using Rex.Core;
using System.Windows.Forms;

namespace Rex.Commands.Mouse
{
    public class Pos : Command
    {
        public override string Key => "pos";

        public override string Do(string line)
        {
            if (line.IsNullOrEmpty())
                return Cursor.Position.X + " " + Cursor.Position.Y;
            else if (line == "x")
                return Cursor.Position.X.ToString();
            else if (line == "y")
                return Cursor.Position.Y.ToString();
            else return "";
        }
    }
}
