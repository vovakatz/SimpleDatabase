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
            if (App.HistoryStack.Count > 0)
                App.CurrentTransactionHistory = App.HistoryStack.Pop();
            else
                App.CurrentTransactionHistory = null;
            return string.Empty;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
