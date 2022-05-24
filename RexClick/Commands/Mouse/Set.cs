using Rex.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rex.Commands.Mouse
{
    public class Set : Command
    {
        public override string Key => "set";

        public override string Do(string line)
        {
            line = line.Trim();
            int x = (int)double.Parse(line.SplitNoNull(' ')[0]);
            int y = (int)double.Parse(line.SplitNoNull(' ')[1]);
            Cursor.Position = new Point(x, y);
            return "";
        }
    }
}
