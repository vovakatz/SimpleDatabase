using Db.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Db
{
	public class Program
	{
		public static void Main(string[] args)
		{
            Dictionary<string, string> simpleDb = new Dictionary<string, string>();
            IDbCommand command;

			while (true)
            {
                string line;
                while ((line = Console.ReadLine().Trim()) == "") ;
                args = line.Split(' ');
                string arg = args[0].ToUpper();
                args = args.Skip(1).ToArray();
                switch (arg)
                {
                    case "SET":
                        command = new Set(simpleDb, args);
                        break;
                    case "GET":
                        command = new Get(simpleDb, args);
                        break;
                    default:
                        Console.WriteLine("you entered unrecognized command");
                        command = null;
                        break;
                }

                if (command != null)
                {
                    if (command.Validate())
                    {
                        string output = command.Perform();
                        if (output != string.Empty)
                            Console.WriteLine(output);
                    }
                }
            }
		}
	}
}
