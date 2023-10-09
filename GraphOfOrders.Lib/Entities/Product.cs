using System.Collections.Generic;

namespace GraphOfOrders.Lib.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }  // Foreign key

        // Navigation properties
        public virtual Category Category { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
    }
}