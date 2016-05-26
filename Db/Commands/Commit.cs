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
            if (App.CurrentTransactionHistory == null)
                return "NO TRANSACTION";
            else
            {
                App.HistoryStack.Clear();
                App.CurrentTransactionHistory = null;
            }
            return string.Empty;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
