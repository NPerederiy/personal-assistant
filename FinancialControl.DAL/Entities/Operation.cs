using System;

namespace FinancialControl.DAL.Entities
{
    public class Operation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public virtual Group Group { get; set; }
        public virtual Category Category { get; set; }
    }
}
