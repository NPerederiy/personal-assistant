using System;
using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid RootCategoryId { get; set; }

        public virtual IEnumerable<SingleCurrencyAccount> SingleCurrencyAccounts { get; set; }
        public virtual IEnumerable<MultiCurrencyAccount> MultiCurrencyAccounts { get; set; }

        public User()
        {
            SingleCurrencyAccounts = new List<SingleCurrencyAccount>();
            MultiCurrencyAccounts = new List<MultiCurrencyAccount>();
        }
    }
}
