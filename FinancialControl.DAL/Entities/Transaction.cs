﻿using System;
using System.Collections.Generic;

namespace FinancialControl.DAL.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public DateTime CommittedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CurrencyCode { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Category Category { get; set; }
        public virtual SingleCurrencyAccount Account { get; set; }
        public virtual IEnumerable<TransactionTags> TransactionTags { get; set; }

        public Transaction()
        {
            TransactionTags = new List<TransactionTags>();
        }
    }
}
