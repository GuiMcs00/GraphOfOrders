using GraphOfOrders.Lib.DTOs;
using System.Threading.Tasks;

namespace GraphOfOrders.Lib.DI
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CreateCustomer(CreateCustomerDTO customer);
        Task<CustomerDTO> GetCustomerById(int id);
    }
}