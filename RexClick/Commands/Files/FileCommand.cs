using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Commands.Files
{
    public class FileCommand : CompositeCommand
    {
        public override string Key => "file";
        public FileCommand() : base(new Add(), new Del(), new Clear(), new Read(), new Write(), new Help()) { }
    }
}
