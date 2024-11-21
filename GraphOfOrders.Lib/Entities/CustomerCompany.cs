using System.Collections.Generic;
using GraphOfOrders.Lib.Entities.Tenant;
using GraphOfOrders.Lib.Enums;
namespace GraphOfOrders.Lib.Entities;

/// <summary>
/// Empresa do Cliente
/// </summary>
public record CustomerCompany(string TenantId) : TenantItemBase(TenantId)
{ 

    /// <summary>
    /// Nome da Empresa do Cliente
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Cadastro Nacional de Pessoa Jurídica Empresa do Cliente
    /// </summary>
    public string Cnpj { get; set; }
    /// <summary>
    /// Inscrição Estadual Empresa do Cliente
    /// </summary>
    public string StateRegistration { get; set; }
    /// <summary>
    /// Inscrição Municipal Empresa do Cliente
    /// </summary>
    public string MunicipalRegistration { get; set; }
    /// <summary>
    /// Regime Tributário da Empresa do Cliente
    /// </summary>
    public TaxRegime TaxRegime { get; set; }
    /// <summary>
    /// Tipo de Empresa do Cliente
    /// </summary>
    public CompanyType CompanyType { get; set; }
    /// <summary>
    /// Porte de Empresa do Cliente
    /// </summary>
    public CompanySize CompanySize { get; set; }

    // Navigation properties
    /// <summary>
    /// Processos/Ações relacionados à Empresa do Cliente
    /// </summary>
    public virtual ICollection<ProcessAction> ProcessActions { get; set; }
    /// <summary>
    /// Associação da Empresa do Cliente e o Funcionário da Contabilidade
    /// </summary>
    public virtual ICollection<CustomerCompanyEmployee> CustomerCompanyEmployees { get; set; }
    /// <summary>
    /// Documetos associados à Empresa do Cliente
    /// </summary>
    public virtual ICollection<Attachment> Documents { get; set; }

}
