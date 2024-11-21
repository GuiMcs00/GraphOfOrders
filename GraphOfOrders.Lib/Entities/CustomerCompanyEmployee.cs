using GraphOfOrders.Lib.Entities.Tenant;

namespace GraphOfOrders.Lib.Entities;

/// <summary>
/// Relação entre Empresa do Cliente e Funcionário Responsável
/// </summary>
public record CustomerCompanyEmployee(string TenantId) : TenantItemBase(TenantId), IEmployeeBound
{
    /// <summary>
    /// Id do Funcioário da Contabilidade responsável pela Empresa do Cliente
    /// </summary>
    public string EmployeeId { get; set; }
    /// <summary>
    /// Funcionário da Contabilidade responsável pela Empresa do Cliente
    /// </summary>
    public Employee Employee { get; set; }
    /// <summary>
    /// Id da Empresa do Cliente
    /// </summary>
    public string CustomerCompanyId { get; set; }
    /// <summary>
    /// Empresa do Cliente
    /// </summary>
    public CustomerCompany CustomerCompany { get; set; }
    
}