using Rex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Application
{
    public class Time : Command
    {
        public override string Key => "time";

        public override string Do(string line)
        {
            return ((int)(DateTime.Now - Config.instance.time).TotalMilliseconds).ToString();
        }
    }
}
