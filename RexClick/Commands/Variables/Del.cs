using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rex.Core;
namespace Rex.Commands.Variables
{
    public class Del : Command
    {
        public override string Key => "del";

        public override string Do(string line)
        {
            Data.Instance.Del(line);
            return "";
        }
    }
}
