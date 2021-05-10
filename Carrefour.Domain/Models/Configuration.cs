using System;
using System.Collections.Generic;
using System.Text;

namespace Carrefour.Domain.Models
{
    public class Configuration : BaseEntity
    {
        public int XFactor { get; set; }
        public int YFactor { get; set; }
    }
}
