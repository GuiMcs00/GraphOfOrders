using System;
using System.Collections.Generic;
using GraphOfOrders.Lib.Enums;

namespace GraphOfOrders.Lib.Entities;

public class ProcessActionType
{
    public int Id { get; set; }
    public int DepartmentId { get; set; } // Foreing Key
    public string Name { get; set; }
    public string Description { get; set; }
    public string ActionTypeName { get; set; }
    

    // Navigation properties
    public virtual ICollection<ProcessAction> ProcessActions { get; set; }
    public virtual Department Department { get; set; }
    
    public void SetActionType<T>(T actionType) where T : Enum
    {
        ActionTypeName = actionType.ToString();
    }
    public T GetActionType<T>() where T : Enum
    {
        return (T)Enum.Parse(typeof(T), ActionTypeName);
    }
}
