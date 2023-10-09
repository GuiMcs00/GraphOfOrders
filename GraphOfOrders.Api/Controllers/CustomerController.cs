using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GraphOfOrders.Api
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CreateCustomerDTO customer)
        {
            var createdCustomer = await _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customerDto = await _customerService.GetCustomerById(id);
                return Ok(customerDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

    }
}
