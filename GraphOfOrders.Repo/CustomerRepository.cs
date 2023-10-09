using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.DI;

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
    }
}