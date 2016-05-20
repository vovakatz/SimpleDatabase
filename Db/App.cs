using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db
{
    public class App
    {
        public static Dictionary<string, string> SimpleDb { get; set; }
        public static Stack<Dictionary<string, string>> SimpleDbTransactions { get; set; }
        public static Dictionary<string, int> SimpleDbCounter { get; set; }

        public static void Init()
        {
            SimpleDb = new Dictionary<string, string>();
            SimpleDbCounter = new Dictionary<string, int>();
        }
    }
}
