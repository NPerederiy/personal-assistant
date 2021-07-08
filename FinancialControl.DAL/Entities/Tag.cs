using System;
using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<TransactionTags> TransactionTags { get; set; }

        public Tag()
        {
            TransactionTags = new List<TransactionTags>();
        }
    }
}
