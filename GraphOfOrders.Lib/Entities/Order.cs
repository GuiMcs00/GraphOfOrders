using System;

namespace GraphOfOrders.Lib.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int BrandId { get; set; }  // Foreign key
        public int CustomerId { get; set; }  // Foreign key
        public DateTime OrderDate { get; set; }

        // Navigation property
        public virtual Brand Brand { get; set; }
        public virtual Customer Customer { get; set; }
    }
}