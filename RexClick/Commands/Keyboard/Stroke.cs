using System.Windows.Forms;

namespace Rex.Commands.Keyboard
{
    public class Stroke : Command
    {
        public override string Key => "stroke";

        public override string Do(string line)
        {
            foreach (char mes in line)
                SendKeys.SendWait(mes.ToString());
            return "";
        }
    }
}