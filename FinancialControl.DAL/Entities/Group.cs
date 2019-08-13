using System;
using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        public virtual IEnumerable<Operation> Operations { get; set; }

        public Group()
        {
            Operations = new List<Operation>();
        }
    }
}
