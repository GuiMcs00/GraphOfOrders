using FluentValidation;
using FluentValidation.Results;
using GraphOfOrders.Lib.DI.Validator;
using GraphOfOrders.Lib.DTOs;

namespace GraphOfOrders.Api.Validator;


public class EmailValidator : AbstractValidator<CustomerInputDTO>, IEmailValidator
{
    public EmailValidator()
    {
        RuleFor(customer => customer.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
    }
    
    public async Task<ValidationResult> ValidateEmail(CustomerInputDTO customer)
    {
        return await ValidateAsync(customer);
    }
}

