using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class DataStorage
    {

        private static Dictionary<string, string> storage = new Dictionary<string, string>();

        public static void setValue(string key, string value)
        {
            storage.Add(key, value);
        }

        public static string getValue(string key)
        {
            return storage[key];
        }

        public static bool hasValue(string key)
        {
            return storage.ContainsKey(key);
        } 

    }
}
