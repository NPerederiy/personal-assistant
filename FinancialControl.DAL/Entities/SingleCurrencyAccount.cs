using System;
using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class SingleCurrencyAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string ValidTo { get; set; }
        public string CardType { get; set; }
        public decimal Balance { get; set; }

        public virtual User Owner { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual MultiCurrencyAccount MultiCurrencyAccount { get; set; }
        public virtual IEnumerable<Transaction> TransactionHistory { get; set; }

        public SingleCurrencyAccount()
        {
            TransactionHistory = new List<Transaction>();
        }
    }
}
