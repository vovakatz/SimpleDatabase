using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public class Set : IDbCommand
    {
        Dictionary<string, string> _simpleDb;
        string[] _args;

        public string Output { get; set; }

        public Set(Dictionary<string, string> simpleDb, string[] args)
        {
            _simpleDb = simpleDb;
            _args = args;
        }

        public string Perform()
        {
            _simpleDb.Add(_args[0], _args[1]);
            return "";
        }

        public bool Validate()
        {
            return true;
        }
    }
}
