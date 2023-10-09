using System.Collections.Generic;

namespace GraphOfOrders.Lib.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ProductId { get; set; }  // Foreign key

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual ICollection<Order> OrdersRecords { get; set; }
    }
}