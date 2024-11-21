using System.Collections.Generic;
using GraphOfOrders.Lib.Entities.Tenant;
using GraphOfOrders.Lib.Enums;

namespace GraphOfOrders.Lib.Entities;

/// <summary>
/// Funcioário de Contabilidade
/// </summary>
public record Employee(string TenantId) : TenantUser(TenantId)
{
    /// <summary>
    /// Nome do Funcionário de Contabilidade
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Id do Departamento do Funcionário de Contabilidade
    /// </summary>
    public string DepartmentId { get; set; } // Foreing Key
    // Navigation properties
    /// <summary>
    /// Coleção de Processos dos Funcionário de Contabilidade
    /// </summary>
    public virtual ICollection<ProcessAction> ProcessActions { get; set; }
    /// <summary>
    /// Coleção de Empresas relacionadas ao Funcionário de Contabilidade
    /// </summary>
    public virtual ICollection<CustomerCompanyEmployee> CustomerCompanyEmployees { get; set; }
    /// <summary>
    /// Departamento do Funcionário de Contabilidade
    /// </summary>
    public virtual Department Department { get; set; }
}
