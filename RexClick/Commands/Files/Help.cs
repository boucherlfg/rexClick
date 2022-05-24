namespace Rex.Commands.Files
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- file <name> : lets you create a file, and its path
- delete <name> : lets you remove a file or directory, including its content
- write <name> <text> : lets you add text content to a file
- read <name> : lets you see text content from a file
- clear <name> : lets you erase the text content of a file";
        }
    }
}