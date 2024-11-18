namespace GraphOfOrders.Lib.Entities;

public class CustomerCompanyEmployee
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    public int CustomerCompanyId { get; set; }
    public CustomerCompany CustomerCompany { get; set; }
    // public string Role { get; set; } 
}