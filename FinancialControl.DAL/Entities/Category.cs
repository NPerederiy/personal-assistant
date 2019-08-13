using System;
using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<Group> Groups { get; set; }
        public virtual IEnumerable<Operation> Operations { get; set; }

        public Category()
        {
            Groups = new List<Group>();
            Operations = new List<Operation>();
        }
    }
}
