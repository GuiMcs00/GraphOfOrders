using System.Collections.Generic;

namespace GraphOfOrders.Lib.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Navigation property
        public virtual ICollection<Order> OrdersHistory { get; set; }
    }
}