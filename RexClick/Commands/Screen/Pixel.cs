using Rex.Core;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Rex.Commands.Screen
{
    public class Pixel : Command
    {
        public override string Key => "pixel";

        public override string Do(string line)
        {

            int x = int.Parse(line.Split(' ')[0]);
            int y = int.Parse(line.Split(' ')[1]);
            string color = line.Split(' ').Skip(2).Join(" ");
            var screen = System.Windows.Forms.Screen.PrimaryScreen;
            using (Bitmap bmp = new Bitmap(screen.Bounds.Width, screen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(0, 0, 0, 0, screen.Bounds.Size);
                    switch (color)
                    {
                        case "R":
                            return bmp.GetPixel(Cursor.Position.X, Cursor.Position.Y).R.ToString();
                        case "G":
                            return bmp.GetPixel(Cursor.Position.X, Cursor.Position.Y).G.ToString();
                        case "B":
                            return bmp.GetPixel(Cursor.Position.X, Cursor.Position.Y).B.ToString();
                        case "A":
                            return bmp.GetPixel(Cursor.Position.X, Cursor.Position.Y).A.ToString();
                        default:
                            return bmp.GetPixel(Cursor.Position.X, Cursor.Position.Y).Name;
                    }
                }
            }
        }
    }
}