using System;
using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class MultiCurrencyAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual User Owner { get; set; }
        public virtual IEnumerable<SingleCurrencyAccount> Accounts { get; set; }

        public MultiCurrencyAccount() : base()
        {
            Accounts = new List<SingleCurrencyAccount>();
        }
    }
}
