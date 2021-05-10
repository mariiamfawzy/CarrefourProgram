using System;
using System.Collections.Generic;
using System.Text;

namespace Carrefour.Domain.Models
{
    public class TransactionType : BaseEntity
    {
        public string Type { get; set; }
        public Transaction Transaction { get; set; }

    }
}
