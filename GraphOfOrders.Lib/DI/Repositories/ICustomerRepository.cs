using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphOfOrders.Lib.DI
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
    }

}
