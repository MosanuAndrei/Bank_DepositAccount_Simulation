using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Bank_Account_Simulation
{
    class Bank
    {
        private event Deposit depositMoney;
        private ArrayList clients;

        public void Init()
        {
            clients = new ArrayList();

            DepositAccount account1 = new DepositAccount("John", AccountType.One_Year);
            clients.Add(account1);
            DepositAccount account2 = new DepositAccount("Jennifer", AccountType.Two_Years);
            clients.Add(account2);
            DepositAccount account3 = new DepositAccount("Susan", AccountType.Three_Years);
            clients.Add(account3);

            this.depositMoney += CheckAccount;
            this.depositMoney += DepositMoney;
        }

        public BankAccount this[int index]
        {
            get
            {
                if (index < 0 || index >= clients.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                IEnumerator enumerator = clients.GetEnumerator();
                for(int i = 0; i <= index; i++)
                {
                    enumerator.MoveNext();
                }
                return (BankAccount)enumerator.Current;
            }
        }

        public void CheckAccount(object sender, DepositArgs args)
        {
            foreach(DepositAccount account in clients)
            {
                if(account.GetWithdrawRequest() == true)
                {
                    clients.Remove(account);
                    break;
                }
            }
        }
        public void DepositMoney(object sender,DepositArgs args)
        {
            foreach(DepositAccount account in clients)
            {
                if(args.AccountId == account.GetAccountId())
                {
                    account.MakeADeposit(args.Amount);
                    break;
                }
            }
        }
        public void DepositTrigger(int accountId, decimal amount)
        {
            if (this.depositMoney != null)
            {
                DepositArgs args = new DepositArgs(accountId, amount);
                this.depositMoney(this, args);
            }
        }
        public void List()
        {
            foreach(DepositAccount account in clients)
            {
                string info = "";
                account.Info(ref info);

                Console.WriteLine(info);
            }
        }
    }
}
