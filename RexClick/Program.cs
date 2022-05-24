using System;
using Rex.Core;
using System.Threading;
using Rex.Hooks;

namespace RexClicker
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "REX CLICK";
            new Thread(new ThreadStart(Mouse.Hook)).Start();
            new Thread(new ThreadStart(Keyboard.Hook)).Start();
            Config.instance.Init();

            if (args.Length >= 1)
            {
                try
                {
                    new Rex.Script().Run(string.Join(" ", args));
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                Environment.Exit(0);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Title = "Rex Clicker";

            Console.WriteLine("welcome to Rex Clicker! Type \"help\" to see what you can do!\n");
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" > ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string line = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Rex.Script.ResolveLine(line).Message();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}