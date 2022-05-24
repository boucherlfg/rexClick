using Rex.Core;
namespace Rex.Commands.Variables
{
    public class Get : Command
    {
        public override string Key => "get";

        public override string Do(string line)
        {
            return Data.Instance[line];
        }
    }
}
