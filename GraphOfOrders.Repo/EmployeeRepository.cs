using GraphOfOrders.Lib.Entities;

namespace GraphOfOrders.Repo;

public class EmployeeRepository : BaseRepository<Employee>
{
    public EmployeeRepository(AccountingContext context) : base(context) {}

    public async Task<Employee> AddEmployeesAsync(Employee employee)
    {
        await AddAsync(employee);
        return employee;
    }
    
    public async Task<Employee> GetEmployeesAsync(string  employeeId)
    {
        return await GetByIdAsync(id:employeeId);
        
    }

    public async Task<Employee> UpdateEmployeesAsync(string id, Employee entryEntity)
    {
        var updatedEntity = await UpdateAsync(id, entryEntity);
        return updatedEntity;
    }

    public async Task<Employee> DeleteEmployeesAsync(string employeeId)
    {
        var deletedEntity = await DeleteAsync(employeeId);
        return deletedEntity;
    }
}