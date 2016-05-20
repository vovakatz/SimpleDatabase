using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public interface IDbCommand
    {
        bool Validate();
        string Perform();
    }
}
