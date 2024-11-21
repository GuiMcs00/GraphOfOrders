namespace GraphOfOrders.Lib.DTOs;

public record CustomerCompany();
public record CustomerCompanyDataEmployeeDashboard
{
    public int CustomerId { get; set; }
    public string CompanyName { get; set; }
    public int Progress { get; set; }
    public string Status { get; set; }
};
