using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rex.Core;
namespace Rex.Commands.Application
{
    public class Wait : Command
    {
        public override string Key => "wait";

        public override string Do(string line)
        {
            var delay = line.ToInt();
            var now = DateTime.Now;
            while ((DateTime.Now - now).TotalMilliseconds < delay) ;
            return "";
        }
    }
}
