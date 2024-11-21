using GraphOfOrders.Lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphOfOrders.Repo;

public class CustomerCompanyEmployeeRepository : BaseRepository<CustomerCompanyEmployee>
{
    public CustomerCompanyEmployeeRepository(AccountingContext context) : base(context) {}

    public async Task<CustomerCompanyEmployee> AddCustomerCompanyEmployee(string employeeId, string customerCompanyId )
    {

        var employee = await _context.Employee.FindAsync(employeeId);
        if (employee == null)
        {
            throw new Exception($"Employee with id {employeeId} does not exist");
        }
        
        var customerCompany = await _context.CustomerCompany.FindAsync(customerCompanyId);
        if (customerCompany == null)
        {
            throw new Exception($"Employee with id {customerCompanyId} does not exist");
        }
        
        var entity = new CustomerCompanyEmployee("Contelb")
        {
            EmployeeId = employee.Id,
            Employee = employee,
            CustomerCompanyId = customerCompany.Id,
            CustomerCompany = customerCompany,
            
        };
        return await AddAsync(entity);
    }
    
    public async Task<IEnumerable<CustomerCompany>> GetCompaniesByEmployeeId(string employeeId)
    {
        var customerCompanyEmployees = await GetByForeignKeyAsync(e => e.EmployeeId == employeeId);
        return customerCompanyEmployees.Select(e => e.CustomerCompany);
    }
    
    public async Task<IEnumerable<Employee>> GetEmployeesByCompanyId(string customerCompanyId)
    {
        var customerCompanyEmployees = await GetByForeignKeyAsync(c => c.CustomerCompanyId == customerCompanyId);
        return customerCompanyEmployees.Select(c => c.Employee);
    }
}