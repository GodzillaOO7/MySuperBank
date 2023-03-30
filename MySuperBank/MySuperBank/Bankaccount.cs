using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    internal class Bankaccount
    {
        public string  Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
        {
            get
            {
                decimal balance =0;
                foreach (var item in AllTransaction)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int AccountNumberSeed = 1234567890;

        private List<Transaction> AllTransaction = new List<Transaction>(); 

        public Bankaccount(string Name, decimal Initialbalance) 
        {
            this.Owner = Name;
            MakeDeposit(Initialbalance, DateTime.Now, "Initial Balance");
            this.Number = AccountNumberSeed.ToString();
            AccountNumberSeed++;
        }


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            } 
            var deposit = new Transaction(amount, date,Balance,note);
            AllTransaction.Add(deposit);
            deposit.Remaining = Balance;
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for the withdrawal");
            }
            var withdrawal = new Transaction(-amount, date,Balance, note);
            AllTransaction.Add(withdrawal);
            withdrawal.Remaining = Balance;
        }
        public string getAccountHistory()
        {
            var accountHistory = new StringBuilder();
            accountHistory.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in AllTransaction)
            {
                accountHistory.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Remaining}\t{item.Notes}");
            }
            return accountHistory.ToString();
        }
    }
}
