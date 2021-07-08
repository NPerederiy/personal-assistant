using System;
using System.Collections.Generic;

namespace FinancialControl.BL.BO
{
    public class CategoryBO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryBO ParentCategory { get; set; }
        public IEnumerable<CategoryBO> Subcategories { get; set; }
        public IEnumerable<TransactionBO> Transactions { get; set; }

        public CategoryBO()
        {
            Subcategories = new List<CategoryBO>();
            Transactions = new List<TransactionBO>();
        }
    }
}
