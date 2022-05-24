using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rex.Commands.Clipboard
{
    public class Set : Command
    {
        public override string Key => "set";

        public override string Do(string line)
        {
            var thr = new Thread(new ThreadStart(() => System.Windows.Forms.Clipboard.SetText(line)));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            thr.Join();
            return "";
        }
    }
}
