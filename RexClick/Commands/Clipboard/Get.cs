using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rex.Commands.Clipboard
{
    public class Get : Command
    {
        public override string Key => "get";

        public override string Do(string line)
        {
            string ret = "";
            var thr = new Thread(new ThreadStart(() =>
            {
                ret = System.Windows.Forms.Clipboard.GetText();
            }));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            thr.Join();
            return ret;
        }
    }
}
