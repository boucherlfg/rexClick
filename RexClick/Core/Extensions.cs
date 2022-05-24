using System.Linq;
using System.Collections.Generic;

namespace Rex.Core
{
    public static class Extension
    {
        public static void Message(this string line)
        {
            if (!string.IsNullOrEmpty(line)) System.Console.WriteLine(line);
        }
        public static string Deformat(this string line)
        {
            line = line.Replace("\\n", "\n");
            line = line.Replace("\\t", "\t");
            line = line.Replace("\\r", "\r");
            line = line.Replace("\\a", "\a");
            line = line.Replace("\\b", "\b");
            line = line.Replace("\\\\", "\\");
            line = line.Replace("\\[", "(");
            line = line.Replace("\\]", ")");
            return line;
        }
        /// <summary>
        /// checks if any string of an array contains given substring
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AnyContains(this IEnumerable<string> list, string value)
        {
            foreach (string item in list)
                if (item.Contains(value)) return true;
            return false;
        }
        /// <summary>
        /// change the way string.Join works
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sep"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> list, string sep)
        {
            return string.Join(sep, list);
        }
        /// <summary>
        /// change the way string.IsNullOrEmpty works
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string line)
        {
            return string.IsNullOrEmpty(line);
        }
        public static float ToFloat(this bool a) => a ? 1 : 0;
        public static float ToFloat(this string a) => float.Parse(a);
        public static int ToInt(this float a) => (int)a;
        public static int ToInt(this string a) => int.Parse(a);
        /// <summary>
        /// go from bool to int
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int ToInt(this bool a)
        {
            return a ? 1 : 0;
        }
        /// <summary>
        /// go from int to bool
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool ToBool(this int a)
        {
            return a != 0;
        }
        /// <summary>
        /// go from double to bool
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool ToBool(this double a)
        {
            return a != 0;
        }
        /// <summary>
        /// go from string to bool, passing to int
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool ToBool(this string a)
        {
            return a != "0";
        }
        /// <summary>
        /// splits and delete null elements
        /// </summary>
        /// <param name="line"></param>
        /// <param name="sep"></param>
        /// <returns></returns>
        public static string[] SplitNoNull(this string line, char sep)
        {
            return line.Split(sep).ToList().FindAll(x => !x.IsNullOrEmpty()).ToArray();
        }
    }
}