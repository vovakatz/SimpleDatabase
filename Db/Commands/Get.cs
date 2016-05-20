using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public class Get : IDbCommand
    {
        Dictionary<string, string> _simpleDb;
        string[] _args;

        public string Output { get; set; }

        public Get(Dictionary<string, string> simpleDb, string[] args)
        {
            _simpleDb = simpleDb;
            _args = args;
        }

        public string Perform()
        {
            return _simpleDb[_args[0]];
        }

        public bool Validate()
        {
            return true;
        }
    }
}
