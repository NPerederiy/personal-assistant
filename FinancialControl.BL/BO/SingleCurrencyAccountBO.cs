using FinancialControl.BL.Enums;
using System;
using System.Collections.Generic;

namespace FinancialControl.BL.BO
{
    public class SingleCurrencyAccountBO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string ValidTo { get; set; }
        public BankCardType CardType { get; set; }
        public decimal Balance { get; set; }

        public virtual UserBO Owner { get; set; }
        public virtual CurrencyBO Currency { get; set; }
        public virtual MultiCurrencyAccountBO MultiCurrencyAccount { get; set; }
        public virtual IEnumerable<TransactionBO> TransactionHistory { get; set; }

        public SingleCurrencyAccountBO()
        {
            TransactionHistory = new List<TransactionBO>();
        }
    }
}
