﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public class Begin : IDbCommand
    {
        public string Perform()
        {
            if (App.CurrentTransactionHistory != null)
                App.HistoryStack.Push(App.CurrentTransactionHistory);
            App.CurrentTransactionHistory = new Stack<KeyValuePair<string, string>>();

            return string.Empty;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
