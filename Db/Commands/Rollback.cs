using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public class Rollback : IDbCommand
    {
        public string Perform()
        {


            return string.Empty;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
