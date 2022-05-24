namespace Rex.Commands.Keyboard
{
    public class Help : Command
    {
        public override string Key => "help";

        public override string Do(string line)
        {
            return @"- block <1|0> : permet de définir si le clavier fonctionne ou pas
- stroke <text> : sends text to any active output 
        (see https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/sendkeys-statement)
- last : returns the value last pressed key
- state <key> : returns the press state of a key";
        }
    }
}