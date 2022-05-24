using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Core
{
    public class Data
    {
        private static Data instance;
        public static Data Instance => instance == null ? (instance = new Data()) : instance;
        private Data()
        {
            variables = new Dictionary<string, string>();
        }
        private readonly Dictionary<string, string> variables;

        public string this[string key]
        {
            get => Has(key) ? variables[key] : throw new Exception("variable " + key + " doesn't exist");
            set => variables[key] = value;
        }
        public bool Has(string key) => variables.ContainsKey(key);
        public void Del(string key) => variables.Remove(key);
    }
}
