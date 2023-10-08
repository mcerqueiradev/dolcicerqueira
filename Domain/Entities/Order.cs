using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal OrderPrice { get; set; }
        public int FK_ProductID { get; set; }
        public int OrderStatus { get; set; }
        public int FK_AuthorId { get; set; }
    }
}
