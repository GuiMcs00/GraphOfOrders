using System.Data;
using AutoMapper;
using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.Exceptions;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using GraphOfOrders.Lib.DI.Validator;

namespace GraphOfOrders.Api
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase 
    {
        private readonly ICustomerService _customerService;
        private readonly IEmailValidator _emailValidator;

        public CustomerController(ICustomerService customerService, IEmailValidator emailValidator)
        {
            _customerService = customerService;
            _emailValidator = emailValidator;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerInputDTO customer)
        {
            ValidationResult validationResult = await _emailValidator.ValidateEmail(customer);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var createdCustomer = await _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
        }

        [HttpGet]
        public IActionResult GetAllCustomers([FromQuery] int? itemsPerPage, [FromQuery] int? page)
        {
            var customers = _customerService.GetCustomers(itemsPerPage ??= 20, page ??= 1);
            return Ok(customers);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerInputDTO updatedCustomerDTO)
        {
            try
            {
                var updatedCustomer = await _customerService.UpdateCustomer(id, updatedCustomerDTO);
                return Ok(updatedCustomer);
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
