using Rex.Core;
namespace Rex.Commands.Network
{
    public class Up : Command
    {
        public override string Key => "up";

        public override string Do(string line)
        {
            Server.instance.ClientUpload(line);
            return "";
        }
    }
}
