
namespace GraphOfOrders.Lib.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class CreateCustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}