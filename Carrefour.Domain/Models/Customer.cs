using System;
using System.Collections.Generic;
using System.Text;

namespace Carrefour.Domain.Models
{
    public class Customer : BaseEntity
    {
        public int TotalXPoints { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
