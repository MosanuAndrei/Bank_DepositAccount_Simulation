using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Bank_Account_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank ing = new Bank();
            ing.Init();

            Console.WriteLine("=========================================================================");
            Console.WriteLine();
            Console.WriteLine("                     Welcome to our Bank Simulation");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Press 1 to show the deposit accounts");
                Console.WriteLine("Press 2 to deposit money into an account");
                Console.WriteLine("Press 3 to exit");

                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        ing.List();
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("For what ID do you wish to deposit money?");
                        string idAsString = Console.ReadLine();
                        int id = Convert.ToInt32(idAsString);
                        Console.WriteLine();
                        Console.WriteLine("How much do you want to deposit?");
                        string amountAsString = Console.ReadLine();
                        decimal amount = Convert.ToDecimal(amountAsString);

                        ing.DepositTrigger(id, amount);
                        Console.WriteLine();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Wrong option, please try again!");
                        Console.WriteLine();
                        break;
                }
            }
        }
        
    }
}
