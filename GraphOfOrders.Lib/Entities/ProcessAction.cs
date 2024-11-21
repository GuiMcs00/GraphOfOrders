using System;
using GraphOfOrders.Lib.Entities.Tenant;
using GraphOfOrders.Lib.Enums;

namespace GraphOfOrders.Lib.Entities;

public record ProcessAction(string TenantId) : TenantItemBase(TenantId), IEmployeeBound
{
    public string EmployeeId { get; set; }
    public string ProcessActionTypeId { get; set; } // Foreing Key
    public string CustomerCompanyId { get; set; } // Foreing Key
    public DateTime CompetencyDate { get; set; }
    public ProcessActionRecurrence Recurrence { get; set; }
    

    // Navigation properties
    public virtual ProcessActionType ProcessActionType { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual CustomerCompany CustomerCompany { get; set; }
}
