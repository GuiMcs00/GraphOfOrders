using GraphOfOrders.Lib.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetCustomers(int itemsPerPage, int page);
        Task<CustomerDTO> CreateCustomer(CustomerInputDTO customer);
        Task<CustomerDTO> GetCustomerById(int id);
        Task<CustomerDTO> UpdateCustomer(int id, CustomerInputDTO updatedCustomerDTO);
    }
}