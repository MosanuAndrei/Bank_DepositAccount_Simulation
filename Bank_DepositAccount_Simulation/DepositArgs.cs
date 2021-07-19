using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Bank_Account_Simulation
{
    class DepositArgs : EventArgs
    {
        private decimal accountId;
        private decimal amount;

        public DepositArgs(decimal accountId, decimal amount)
        {
            this.accountId = accountId;
            this.amount = amount;
        }

        public decimal AccountId
        {
            get { return this.accountId; }
        }
        public decimal Amount
        {
            get { return this.amount; }
        }
    }
}
