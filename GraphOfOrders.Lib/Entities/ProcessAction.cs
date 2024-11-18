using System;
using GraphOfOrders.Lib.Enums;

namespace GraphOfOrders.Lib.Entities;

public class ProcessAction
{
    public int Id { get; set; }
    public int ProcessActionTypeId { get; set; } // Foreing Key
    public int CustomerCompanyId { get; set; } // Foreing Key
    public int EmployeeId { get; set; } // Foreing Key
    public DateTime CompetencyDate { get; set; }
    public ProcessActionRecurrence Recurrence { get; set; }
    

    // Navigation properties
    public virtual ProcessActionType ProcessActionType { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual CustomerCompany CustomerCompany { get; set; }
}
