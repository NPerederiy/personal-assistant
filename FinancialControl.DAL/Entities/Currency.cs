using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class Currency
    {
        public string Name { get; set; }
        public string ISO_4217_Code { get; set; }
        public string ISO_4217_Number { get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }

        public Currency()
        {
            Transactions = new List<Transaction>();
        }
    }
}
