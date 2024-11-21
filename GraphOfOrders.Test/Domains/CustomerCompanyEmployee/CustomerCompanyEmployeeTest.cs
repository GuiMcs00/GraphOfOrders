using GraphOfOrders.Lib.Enums;
using GraphOfOrders.Repo;
using Microsoft.EntityFrameworkCore;

namespace GraphOfOrders.Test.Domains.CustomerCompanyEmployee;

public class TestDataFactory
{
    public static Lib.Entities.CustomerCompany CustomerCompanyPayload
        (string name = "Acme Corp",string cnpj = "000", TaxRegime regime = TaxRegime.SimplesNacional)
    {
        return new Lib.Entities.CustomerCompany("Contelb")
        {
            Name = name,
            Cnpj = cnpj,
            StateRegistration = "000",
            MunicipalRegistration = "000",
            TaxRegime = regime,
            CompanyType = CompanyType.MEI,
            CompanySize = CompanySize.Microempresa
        };
    }
    
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

public class CustomerCompanyEmployeeTest : IDisposable
{
    private readonly AccountingContext _context;
    private readonly EmployeeRepository _repoEmployee;
    private readonly CustomerCompanyRepository _repoCustomerCompany;
    private readonly CustomerCompanyEmployeeRepository _repoCustomerCompanyEmployee;

    public CustomerCompanyEmployeeTest()
    {
        var options = new DbContextOptionsBuilder<AccountingContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AccountingContext(options);
        _repoEmployee = new EmployeeRepository(_context);
        _repoCustomerCompany = new CustomerCompanyRepository(_context);
        _repoCustomerCompanyEmployee = new CustomerCompanyEmployeeRepository(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Fact]
    public async Task Should_Associate_Employee_To_Company()
    {
        // Arrange
        var employee = await _repoEmployee.AddEmployeesAsync(TestDataFactory.EmployeePayload());
        var customerCompany = await _repoCustomerCompany.AddCustomerCompanyAsync(TestDataFactory.CustomerCompanyPayload());

        // Act
        var result = await _repoCustomerCompanyEmployee
            .AddCustomerCompanyEmployee(employeeId:employee.Id, customerCompanyId:customerCompany.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(employee, result.Employee);
        Assert.Equal(customerCompany, result.CustomerCompany);
    }

    [Fact]
    public async Task Should_Get_Company_By_One_EmployeeId()
    {
        // Arrange
        var employee = await _repoEmployee.AddEmployeesAsync(TestDataFactory.EmployeePayload());
        var customerCompany = await _repoCustomerCompany.AddCustomerCompanyAsync(TestDataFactory.CustomerCompanyPayload());
        var customerCompanyEmployee = await _repoCustomerCompanyEmployee
            .AddCustomerCompanyEmployee(employeeId:employee.Id, customerCompanyId:customerCompany.Id);
        
        // Act
        var result = await _repoCustomerCompanyEmployee.GetCompaniesByEmployeeId(employee.Id);
        
        // Assert
        Assert.NotNull(result);
        var companyList = result.ToList();
        Assert.Single(companyList);
        Assert.Equal(customerCompany.Id, companyList[0].Id);
        Assert.Equal(customerCompany, companyList[0]);
    }
    
    [Fact]
    public async Task Should_Get_Employee_By_One_CompanyId()
    {
        // Arrange
        var employee = await _repoEmployee
            .AddEmployeesAsync(TestDataFactory.EmployeePayload());
        var customerCompany = await _repoCustomerCompany
            .AddCustomerCompanyAsync(TestDataFactory.CustomerCompanyPayload());
        var customerCompanyEmployee = await _repoCustomerCompanyEmployee
            .AddCustomerCompanyEmployee(employeeId:employee.Id, customerCompanyId:customerCompany.Id);
        
        // Act
        var result = await _repoCustomerCompanyEmployee
            .GetEmployeesByCompanyId(customerCompany.Id);
        
        // Assert
        Assert.NotNull(result);
        var employeeList = result.ToList();
        Assert.Single(employeeList);
        Assert.Equal(employee.Id, employeeList[0].Id);
        Assert.Equal(employee, employeeList[0]);
    }
    
    [Fact]
    public async Task Should_Associate_More_Than_One_Employee_To_Company()
    {
        // Arrange
        var employees = new[]
        {
            await _repoEmployee.AddEmployeesAsync(TestDataFactory
            .EmployeePayload(name: "Guilherme", department: "1", roles: Roles.PeopleEmployee)),
            await _repoEmployee.AddEmployeesAsync(TestDataFactory
            .EmployeePayload(name: "Stephane", department: "2", roles: new[] {Roles.TaxSupervisor, Roles.TaxEmployee})),
            await _repoEmployee.AddEmployeesAsync(TestDataFactory
            .EmployeePayload(name: "Juliana", department: "3", roles: new[] {Roles.AccountingSupervisor, Roles.AccountingEmployee}))
        };
        
        var customerCompany = await _repoCustomerCompany.AddCustomerCompanyAsync(TestDataFactory.CustomerCompanyPayload());
    
        // Act (Adding one by one for now)
        var results = new List<Lib.Entities.CustomerCompanyEmployee>();
        foreach (var employee in employees)
        {
            var result = await _repoCustomerCompanyEmployee.AddCustomerCompanyEmployee(
                employeeId: employee.Id, customerCompanyId: customerCompany.Id);
            results.Add(result);
        }
        
    
        // Assert
        Assert.All(results, Assert.NotNull);
        for (int i = 0; i < employees.Length; i++)
        {
            Assert.Equal(employees[i], results[i].Employee);
            Assert.Equal(customerCompany, results[i].CustomerCompany);
        }

    }
    
    // [Fact]
    // public async Task Should_Get_Company_By_Multiple_EmployeeId()
    // {
    //     // Arrange
    //     var employees = new[]
    //     {
    //         await _repoEmployee.AddEmployeesAsync(TestDataFactory
    //             .EmployeePayload(name: "Guilherme", department: "1", roles: Roles.PeopleEmployee)),
    //         await _repoEmployee.AddEmployeesAsync(TestDataFactory
    //             .EmployeePayload(name: "Stephane", department: "2", roles: new[] {Roles.TaxSupervisor, Roles.TaxEmployee})),
    //         await _repoEmployee.AddEmployeesAsync(TestDataFactory
    //             .EmployeePayload(name: "Juliana", department: "3", roles: new[] {Roles.AccountingSupervisor, Roles.AccountingEmployee}))
    //     };
    //     
    //     var customerCompany = await _repoCustomerCompany.AddCustomerCompanyAsync(TestDataFactory.CustomerCompanyPayload());
    //
    //     // Act
    //     var result = await _repoCustomerCompanyEmployee.GetCompaniesByEmployeeId(customerCompanyEmployee.EmployeeId);
    //     
    //     // Assert
    //     Assert.NotNull(result);
    // }
    
}