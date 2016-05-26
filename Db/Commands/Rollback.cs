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
            if (App.CurrentTransactionHistory == null)
                return "NO TRANSACTION";
            else
            {
                App.IsRollbackActive = true;
                while (App.CurrentTransactionHistory != null && App.CurrentTransactionHistory.Count > 0)
                {
                    var item = App.CurrentTransactionHistory.Pop();
                    if (item.Value == null)
                    {
                        IDbCommand unset = new Unset(new string[] { item.Key, item.Value });
                        unset.Perform();
                    }
                    else
                    {
                        IDbCommand set = new Set(new string[] { item.Key, item.Value });
                        set.Perform();
                    }
                }

                if (App.HistoryStack.Count > 0)
                    App.CurrentTransactionHistory = App.HistoryStack.Pop();
                else
                    App.CurrentTransactionHistory = null;

                App.IsRollbackActive = false;
            }
            return string.Empty;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
