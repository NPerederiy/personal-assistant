using System;

namespace FinancialControl.DAL.Entities
{
    public class TransactionTags
    {
        public Guid TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }

        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
