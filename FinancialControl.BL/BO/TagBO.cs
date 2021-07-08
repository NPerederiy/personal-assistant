using System;
using System.Collections.Generic;

namespace FinancialControl.BL.BO
{
    public class TagBO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<TransactionBO> Transactions { get; set; }

        public TagBO()
        {
            Transactions = new List<TransactionBO>();
        }
    }
}
