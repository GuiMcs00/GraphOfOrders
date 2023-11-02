using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GraphOfOrders.Repo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrdersContext _context;

        public CustomerRepository(OrdersContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var customerEntityEntry = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customerEntityEntry.Entity;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public async Task<Customer> UpdateCustomer(int id, Customer updatedCustomer)
        {
            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null)
            {
                return null; // or you might want to throw a not found exception
            }

            // Update the properties of the existing customer entity
            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.Email = updatedCustomer.Email;

            await _context.SaveChangesAsync();
            return existingCustomer;
        }

    }
}