
namespace Rex.Commands
{
    public class Main : CompositeCommand
    {
        public override string Key => "";
        public Main() : base(
            new Application.App(), new Clipboard.Clip(), new Console.ConsoleCommand(), 
            new Files.FileCommand(), new Keyboard.KeyCommand(), new Mouse.MouseCommand(), new Network.Net(),
            new Path.PathCommand(), new Screen.ScreenCommand(), new Help(), new Variables.Var()) 
        {
            commands.AddRange(new Math.MathCommand());
        }
    }
}
