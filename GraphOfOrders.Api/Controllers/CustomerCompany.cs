using GraphOfOrders.Lib.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GraphOfOrders.Api.Controllers
{
    [ApiController]
    [Route("dashboard/[controller]")]
    public class CustomerCompany : ControllerBase
    {
        [HttpGet("companies")]
        public ActionResult<IEnumerable<CustomerCompanyDataEmployeeDashboard>> GetCompanies()
        {
            var companies = new List<CustomerCompanyDataEmployeeDashboard>
            {
                new CustomerCompanyDataEmployeeDashboard { CustomerId = 1, CompanyName = "Acme Corp", Progress = 75, Status = "in-progress" },
                new CustomerCompanyDataEmployeeDashboard { CustomerId = 2, CompanyName = "Globex", Progress = 100, Status = "completed" },
                new CustomerCompanyDataEmployeeDashboard { CustomerId = 3, CompanyName = "Soylent Corp", Progress = 30, Status = "in-progress" },
                new CustomerCompanyDataEmployeeDashboard { CustomerId = 4, CompanyName = "Initech", Progress = 0, Status = "pending" },
                new CustomerCompanyDataEmployeeDashboard { CustomerId = 5, CompanyName = "Umbrella Corp", Progress = 50, Status = "in-progress" },
                new CustomerCompanyDataEmployeeDashboard { CustomerId = 6, CompanyName = "Hooli", Progress = 90, Status = "in-progress" }
            };

            return Ok(companies);
        }
        
    }
}

    