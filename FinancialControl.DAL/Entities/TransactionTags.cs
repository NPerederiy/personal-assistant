using System;

namespace FinancialControl.DAL.Entities
{
    public class TransactionTags
    {
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
