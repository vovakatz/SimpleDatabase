using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public class Set : IDbCommand
    {
        string[] _args;

        public string Output { get; set; }

        public Set(string[] args)
        {
            _args = args;
        }

        public string Perform()
        {
            Unset unset = new Unset(_args);
            unset.Perform();
            App.SimpleDb.Add(_args[0], _args[1]);

            int count;
            if (App.SimpleDbCounter.TryGetValue(_args[1], out count))
                App.SimpleDbCounter[_args[1]] = ++count;
            else
                App.SimpleDbCounter.Add(_args[1], 1);
            return "";
        }

        public bool Validate()
        {
            return true;
        }
    }
}
