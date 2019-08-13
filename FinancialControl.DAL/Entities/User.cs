using System;
using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public virtual IEnumerable<Category> Categories { get; set; }

        public User()
        {
            Categories = new List<Category>();
        }
    }
}
