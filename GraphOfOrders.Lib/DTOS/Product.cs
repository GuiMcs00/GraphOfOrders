using System;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }  // Foreign key
    }
}