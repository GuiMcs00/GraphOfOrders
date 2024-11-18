using System.Collections.Generic;
using GraphOfOrders.Lib.Enums;
namespace GraphOfOrders.Lib.Entities;

public class CustomerCompany
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string StateRegistration { get; set; }
    public string MunicipalRegistration { get; set; }
    //public List<int> CustomerEmployeeIds { get; set; } the database provider does not support this type
    public string Documents { get; set; }
    public TaxRegime TaxRegime { get; set; }
    public CompanyType CompanyType { get; set; }
    public CompanySize CompanySize { get; set; }

    // Navigation properties
    public virtual ICollection<ProcessAction> ProcessActions { get; set; }
    public virtual ICollection<CustomerCompanyEmployee> CustomerCompanyEmployees { get; set; }

}
