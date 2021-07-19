using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_Sharp_Bank_Account_Simulation
{
    class DepositAccount : BankAccount
    {
        private bool withdrawRequest = false;
        private decimal amount;
        private double interestAmount;
        private AccountType accountType;

        public DepositAccount(string name, AccountType type) : base(name)
        {
            this.accountType = type;
        }

        public void MakeADeposit(decimal amountToDeposit)
        {
            this.amount += amountToDeposit;
            switch (accountType)
            {
                case AccountType.One_Year:
                    interestAmount += (int)amountToDeposit * 0.04;
                    break;
                case AccountType.Two_Years:
                    interestAmount += (int)amountToDeposit * 0.06;
                    break;
                case AccountType.Three_Years:
                    interestAmount += (int)amountToDeposit * 0.08;
                    break;
            }
            FileStream fileStream = new FileStream(this.logFile, FileMode.Append);
            using (StreamWriter fout = new StreamWriter(fileStream))
            {
                fout.WriteLine(DateTime.Now + ";Amount Deposited:" + amountToDeposit + ";Interest Amount:" + this.interestAmount);
                fout.Close();
            }
        }

        public override void Info(ref string info)
        {
            base.Info(ref info);
            info +="Amount Deposited: " + this.amount + "\n" + "Interest Amount: " + this.interestAmount;
        }
        public bool GetWithdrawRequest()
        {
            return this.withdrawRequest;
        }
    }
}
