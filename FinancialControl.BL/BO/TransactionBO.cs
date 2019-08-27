using System;
using System.Collections.Generic;

namespace FinancialControl.BL.BO
{
    public class TransactionBO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public DateTime CommitedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CurrencyBO Currency { get; set; }
        public CategoryBO Category { get; set; }
        public IEnumerable<TagBO> Tags { get; set; }

        public TransactionBO()
        {
            Tags = new List<TagBO>();
        }
    }
}
