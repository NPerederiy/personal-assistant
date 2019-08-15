using System;

namespace FinancialControl.DAL.Entities
{
    public class Operation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public string CurrencyCode { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Category Category { get; set; }
    }
}
