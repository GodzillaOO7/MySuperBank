using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    public class Transaction
    {
        public decimal Amount {  get; }
        public DateTime Date { get; }
        public string Notes { get; }
        public decimal Remaining { get; set; }

        public Transaction(decimal amount, DateTime date,decimal balance, string notes)
        {
            this.Amount = amount;
            this.Date = date;
            this.Remaining = balance;
            this.Notes = notes;
        }
    }
}
