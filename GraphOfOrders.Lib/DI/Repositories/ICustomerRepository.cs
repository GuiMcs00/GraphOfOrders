using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphOfOrders.Lib.DI
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers(int howMany, int page);  
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<Customer> UpdateCustomer(int id, Customer updatedCustomer);
    }

}
