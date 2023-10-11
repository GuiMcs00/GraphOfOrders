using GraphOfOrders.Lib.DTOs;
using System.Threading.Tasks;

namespace GraphOfOrders.Lib.DI
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CreateCustomer(CustomerInputDTO customer);
        Task<CustomerDTO> GetCustomerById(int id);
        Task<CustomerDTO> UpdateCustomer(int id, CustomerInputDTO updatedCustomerDTO);
    }
}