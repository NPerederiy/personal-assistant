using System;
using System.Collections.Generic;

namespace FinancialControl.BL.BO
{
    public class MultiCurrencyAccountBO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual UserBO Owner { get; set; }
        public virtual IEnumerable<SingleCurrencyAccountBO> Accounts { get; set; }

        public MultiCurrencyAccountBO()
        {
            Accounts = new List<SingleCurrencyAccountBO>();
        }
    }
}
