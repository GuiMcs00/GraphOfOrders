using System.Collections.Generic;

namespace GraphOfOrders.Lib.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SupervisorId { get; set; } // Foreign Key for Supervisor
    public virtual Employee Supervisor { get; set; } // Supervisor as an Employee

    // Navigation properties
    public virtual ICollection<Employee> Employees { get; set; }
    public virtual ICollection<ProcessActionType> ProcessActionTypes { get; set; }
}