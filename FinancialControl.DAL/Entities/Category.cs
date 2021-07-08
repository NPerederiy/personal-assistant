using System;
using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual IEnumerable<Category> Subcategories { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }

        public Category()
        {
            Subcategories = new List<Category>();
            Transactions = new List<Transaction>();
        }
    }
}
