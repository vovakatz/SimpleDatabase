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
            App.IsRollbackActive = true;
            while(App.CurrentTransactionHistory != null && App.CurrentTransactionHistory.Count > 0)
            {
                var item = App.CurrentTransactionHistory.Pop();
                IDbCommand set = new Set(new string[] { item.Key, item.Value} );
                set.Perform();
            }
            App.IsRollbackActive = false;
            return string.Empty;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
