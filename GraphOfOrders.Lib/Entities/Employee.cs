using System.Collections.Generic;

namespace GraphOfOrders.Lib.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; } // Foreing Key

    // Navigation properties
    public virtual ICollection<ProcessAction> ProcessActions { get; set; }
    public virtual ICollection<CustomerCompanyEmployee> CustomerCompanyEmployees { get; set; }
    public virtual Department Department { get; set; }
}
