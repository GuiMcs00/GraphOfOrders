using System;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int BrandId { get; set; }  // Foreign key
        public DateTime OrderDate { get; set; }
    }
}