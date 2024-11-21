using System;
using System.Collections.Generic;
using GraphOfOrders.Lib.Entities.Tenant;
using GraphOfOrders.Lib.Enums;

namespace GraphOfOrders.Lib.Entities;

/// <summary>
/// Tipo de Processo
/// </summary>
/// <param name="TenantId"></param>
public record ProcessActionType(string TenantId) : TenantItemBase(TenantId), IDepartmentBound
{
    /// <summary>
    /// Id do Departamento Associado ao Tipo de Processo
    /// </summary>
    public string DepartmentId { get; set; } // Foreing Key
    /// <summary>
    /// Nome do Tipo de Processo 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Descrição do Tipo de Processo
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Enum de Tipo de Processo
    /// </summary>
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
