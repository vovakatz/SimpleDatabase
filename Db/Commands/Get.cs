﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Commands
{
    public class Get : IDbCommand
    {
        string[] _args;

        public string Output { get; set; }

        public Get(string[] args)
        {
            _args = args;
        }

        public string Perform()
        {
            string value;
            if (App.SimpleDb.TryGetValue(_args[0], out value))
                return value;
            return "NULL";
        }

        public bool Validate()
        {
            return true;
        }
    }
}
