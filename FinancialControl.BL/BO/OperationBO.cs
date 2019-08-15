using System;

namespace FinancialControl.BL.BO
{
    public class OperationBO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public CurrencyBO Currency { get; set; }
        public CategoryBO Category { get; set; }
    }
}
