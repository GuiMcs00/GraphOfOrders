using System;

namespace GraphOfOrders.Lib
{
    public class Order
    {
        public int OrderId { get; set; }
        public int BrandId { get; set; }  // Foreign key
        public DateTime OrderDate { get; set; }

        // Navigation property
        public virtual Brand Brand { get; set; }
    }
}