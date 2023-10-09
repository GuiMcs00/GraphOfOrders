using System.Collections.Generic;

namespace GraphOfOrders.Lib.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
}