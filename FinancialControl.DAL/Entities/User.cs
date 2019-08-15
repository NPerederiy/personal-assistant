using System;

namespace FinancialControl.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid RootCategoryId { get; set; }
    }
}
