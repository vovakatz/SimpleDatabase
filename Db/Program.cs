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
            IDbCommand command;
            App.Init();

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
                        command = new Set(args);
                        break;
                    case "GET":
                        command = new Get(args);
                        break;
                    case "UNSET":
                        command = new Unset(args);
                        break;
                    case "NUMEQUALTO":
                        command = new NumEqualTo(args);
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
