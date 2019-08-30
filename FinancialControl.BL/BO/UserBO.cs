using System;
using System.Collections.Generic;

namespace FinancialControl.BL.BO
{
    public class UserBO
    {
        public Guid Id { get; set; }
        public Guid RootCategoryId { get; set; }
        public IEnumerable<SingleCurrencyAccountBO> SingleCurrencyAccounts { get; set; }
        public IEnumerable<MultiCurrencyAccountBO> MultiCurrencyAccounts { get; set; }

        public UserBO()
        {
            SingleCurrencyAccounts = new List<SingleCurrencyAccountBO>();
            MultiCurrencyAccounts = new List<MultiCurrencyAccountBO>();
        }
    }
}
