using System;
using System.ComponentModel.DataAnnotations;

namespace Carrefour.Domain
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
