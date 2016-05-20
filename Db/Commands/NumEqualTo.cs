using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public class NumEqualTo : IDbCommand
    {
        string[] _args;
        public NumEqualTo(string[] args)
        {
            _args = args;
        }

        public string Perform()
        {
            int count;
            if (App.SimpleDbCounter.TryGetValue(_args[0], out count))
                return count.ToString();
            return "0";
        }

        public bool Validate()
        {
            return true;
        }
    }
}
