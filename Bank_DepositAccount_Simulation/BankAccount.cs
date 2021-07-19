using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Bank_Account_Simulation
{
    class BankAccount
    {
        protected string name;
        protected static int numberGenerator = 1234;
        protected int accountId;
        protected string logFile;

        public BankAccount(string name)
        {
            this.name = name;
            this.accountId = IdGenerator();
            this.logFile = this.accountId + ".txt";
        }

        public int IdGenerator()
        {
            numberGenerator++;
            return numberGenerator;
        }

        public string GetName()
        {
            return this.name;
        }
        public int GetAccountId()
        {
            return this.accountId;
        }

        public virtual void Info(ref string info)
        {
            info += "\n" + "Account Name: " + this.name + "\n" + "Account ID: " + this.accountId + " " + "\n";
        }
    }
}
