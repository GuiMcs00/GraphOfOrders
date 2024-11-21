using System.Collections.Generic;
using GraphOfOrders.Lib.Entities.Tenant;

namespace GraphOfOrders.Lib.Entities;

/// <summary>
/// Departamentos de Contabilidade
/// </summary>
public record Department(string TenantId) : TenantItemBase(TenantId)
{
    /// <summary>
    /// Nome do Departamento
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Id do Funcionário Supervisor de Departamento
    /// </summary>
    public string SupervisorId { get; set; } // Foreign Key for Supervisor
    /// <summary>
    /// Supervisor de Departamento
    /// </summary>
    public virtual Employee Supervisor { get; set; } // Supervisor as an Employee

    // Navigation properties
    /// <summary>
    /// Coleção de Funcionários do Departamento 
    /// </summary>
    public virtual ICollection<Employee> Employees { get; set; }
    /// <summary>
    /// Coleção de Processos do Departamento
    /// </summary>
    public virtual ICollection<ProcessActionType> ProcessActionTypes { get; set; }
}