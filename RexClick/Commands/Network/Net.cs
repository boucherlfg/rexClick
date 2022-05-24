using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Network
{
    public class Net : CompositeCommand
    {
        public override string Key => "net";

        public Net() : base(
            new Info(), new Down(), new IP(), 
            new Listen(), new Listening(), new LocalIP(),
            new Ping(), new Port(), new Scan(), 
            new Send(), new Up()) { }
    }
}
