using System.IO;
using System.Text;
using System.Linq;
using System.Diagnostics;
using Rex.Commands;
using System;
using Rex.Core;
using System.Threading;
using System.Collections.Generic;

namespace Rex
{
    public class Script
    {
        static readonly Main main = new Main();
        public string Execute(string line)
        {
            name = line.Split(' ').First();
            string args = line.Split(' ').Skip(1).Join(" ");
            using (Process p = new Process())
            {
                p.StartInfo.FileName = name;
                p.StartInfo.Arguments = args;
                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.UseShellExecute = false;
                //p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                //line = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            return "";
            //return line;
        }
        public string Run(string line)
        {
            line = line.Replace("/", "\\");
            name = Path.GetFullPath(line.Split(' ').First());
            string[] args = line.Split(' ').Skip(1).ToArray();

            //lire toutes les lignes du fichier
            string[] lines = File.ReadAllLines(name, Encoding.UTF8);
            lines = DealWithArguments(lines, args);

            while (line != null && running)
            {
                //lire la ligne numéro n (donné par "flow") du fichier
                line = Flow(lines);
                //si la ligne n'a pas de contenu, on continue, puis le while nous fera sortir de la boucle.
                if (line == null)
                    continue;
                //on exécute la commande
                line = ResolveLine(line);
                //on retourne ce que la commande nous a dit en out.
            }
            
            return "";
        }

        public string name;
        /// <summary>
        /// tracker for the "flow" method
        /// </summary>
        public int flowindex;
        private bool running;

        public Script()
        {
            flowindex = 0;
            running = true;
            new Thread(() =>
            {
                while (true)
                {
                    if (Hooks.Keyboard.Last == "Escape")
                    {
                        running = false;
                        break;
                    }
                }
            }).Start();
        }

        /// <summary>
        /// permet de changer le flow des scripts considérablement (?!:/)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        string Flow(string[] list)
        {
            string temp = "";
            string test;
            //tant que l'index est dans les limites du stack, on continue
            while (flowindex < list.Length && flowindex > -1)
            {
                //on prend la commande d'index i
                temp = list[flowindex].Replace("\t", "");
                //on change les commandes embeddées pour leurs retour
                //si il n'y a pas de commande, on incrémente
                if (string.IsNullOrEmpty(temp)) { flowindex++; continue; }
                switch (temp[0])
                {
                    case '!':
                        temp = Embedded(temp);
                        //trouver l'index du label donné
                        if (list.AnyContains(":" + temp.Substring(1)))
                            flowindex = list.ToList().IndexOf(":" + temp.Substring(1));
                        continue;
                    case '?':
                        //trouver l'index du label donné si la condition est affirmée vraie
                        test = temp.Split('?')[1];
                        test = string.Join("!", test.Split('!').Take(test.Split('!').Length - 1));
                        test = Embedded(test);
                        if (test.ToBool())
                            flowindex = list.ToList().IndexOf(":" + temp.Split('!').Last());
                        else
                            flowindex++;
                        continue;
                    case ':':
                        //le label. on ne l'exécute pas : on exécute la ligne suivante
                        flowindex++;
                        continue;
                    case '/':
                        //un commentaire. on ne l'exécute pas
                        flowindex++;
                        continue;
                    default:
                        //on incrémente pour la prochaine lecture, et on retourne la ligne qu'on vient de trouver
                        flowindex++;
                        return temp;
                }
            }
            return null;
        }

        private static string[] DealWithArguments(string[] lines, string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    lines[j] = lines[j].Replace("#" + i, args[i]);
                }
            }
            return lines;
        }
        private static string Embedded(string line)
        {
            if (line.Split('(').Length != line.Split(')').Length) throw new Exception("invalid parenthesis");
            while (line.Contains("("))
            {
                var bit = line.Split(')').First().Split('(').Last();
                line = line.Replace("(" + bit + ")", ResolveLine(bit));
            }
            return line;
        }

        [STAThread]
        public static string ResolveLine(string line)
        {
            line = Embedded(line);
            line = line.Deformat();
            if (main.IsValid(line))
            {
                return main.Do(line);
            }
            return line;
        }
    }
}