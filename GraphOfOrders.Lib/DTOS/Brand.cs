
namespace GraphOfOrders.Lib.DTOs
{
    public class BrandDTO
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ProductId { get; set; }  // Foreign key
    }
}