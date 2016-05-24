using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public class Unset : IDbCommand
    {
        string[] _args;

        public string Output { get; set; }

        public Unset(string[] args)
        {
            _args = args;
        }

        public string Perform()
        {
            if (App.CurrentTransactionHistory != null && !App.IsRollbackActive)
                if (App.SimpleDb[_args[0]] != null)
                    App.CurrentTransactionHistory.Push(new KeyValuePair<string, string>(_args[0], App.SimpleDb[_args[0]]));

            string value;
            if (App.SimpleDb.TryGetValue(_args[0], out value))
            {
                App.SimpleDb.Remove(_args[0]);
                int count;
                if (App.SimpleDbCounter.TryGetValue(value, out count))
                {
                    if (count == 1)
                        App.SimpleDbCounter.Remove(value);
                    else
                        App.SimpleDbCounter[value] = --count;
                }
            }
            return string .Empty;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
