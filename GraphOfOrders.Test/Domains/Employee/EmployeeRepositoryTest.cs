using GraphOfOrders.Lib.Enums;
using GraphOfOrders.Repo;
using Microsoft.EntityFrameworkCore;

namespace GraphOfOrders.Test.Domains.Employee;

public class TestDataFactory
{
    public static Lib.Entities.Employee EmployeePayload
        (string name = "John Doe", string department = "1", params Roles[] roles)
    {
        return new Lib.Entities.Employee("Contelb")
        {
            Name = name,
            DepartmentId = department,
            Role = roles.ToList(),
        };
    }
}

public class EmployeeRepositoryTest : IDisposable
{
    private readonly AccountingContext _context;
    private readonly EmployeeRepository _repo;

    public EmployeeRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<AccountingContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AccountingContext(options);
        _repo = new EmployeeRepository(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Fact]
    public async Task Should_Create_Employee()
    {
        // Arrange 
        var employeePayload = TestDataFactory.EmployeePayload(roles: new[] { Roles.TaxEmployee, Roles.TaxSupervisor });
        
        // Act
        var result = await _repo.AddEmployeesAsync(employeePayload);
        
        //Assert
        Assert.NotNull(result);
        Assert.Equal(employeePayload.Id, result.Id);
    }

    [Fact]
    public async Task Should_Get_Employee()
    {
        // Arrange
        var employeePayload = TestDataFactory.EmployeePayload(roles: new[] { Roles.TaxEmployee, Roles.TaxSupervisor });
        
        await _repo.AddEmployeesAsync(employeePayload);
        
        // Act
        var result = await _repo.GetEmployeesAsync(employeePayload.Id);
        
        //Assert 
        Assert.NotNull(result);
        Assert.Equal(employeePayload.Id, result.Id);
    }
    
}
