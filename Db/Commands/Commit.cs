using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public class Commit : IDbCommand
    {
        public string Perform()
        {
            App.CurrentTransactionHistory = App.HistoryStack.Pop();
            return string.Empty;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
