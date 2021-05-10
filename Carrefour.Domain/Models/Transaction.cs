using System;
using System.Collections.Generic;
using System.Text;

namespace Carrefour.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public int CustomerID { get; set; }
        public TransactionType Type { get; set; }
        public int SpentAmount { get; set; }
        public int XPoints { get; set; }
        public DateTime CreatedDate { get; set; }

        public Boolean Expired { get; set; }

        public Customer Customer { get; set; }
    }
}
