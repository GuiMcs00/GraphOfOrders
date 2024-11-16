using FluentValidation.TestHelper;
using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Api.Validator;
using Xunit;

namespace GraphOfOrders.Test.Domains.Customer;

public class CustomerEmailValidator
{
    private readonly EmailValidator _validator;

    public CustomerEmailValidator()
    {
        _validator = new EmailValidator();
    }
    
    [Fact]
    public void Should_Have_Error_When_Email_Is_Empty()
    {
        // Arrange
        var customerDto = new CustomerInputDTO { Email = "" };

        // Act & Assert
        var result = _validator.TestValidate(customerDto);
        result.ShouldHaveValidationErrorFor(customer => customer.Email)
            .WithErrorMessage("Email is required.");
    }

    [Fact]
    public void Should_Have_Error_When_Email_Is_Null()
    {
        // Arrange
        var customerDto = new CustomerInputDTO { Email = null };
        
        // Act & Assert
        var result = _validator.TestValidate(customerDto);
        result.ShouldHaveValidationErrorFor(customer => customer.Email)
            .WithErrorMessage("Email is required.");
    }

    [Fact]
    public void Should_Have_Error_When_Email_Is_Not_Valid()
    {
        // Arrange
        var customerDto = new CustomerInputDTO { Email = "testtest.com" };
        
        // Act & Action
        var result = _validator.TestValidate(customerDto);
        result.ShouldHaveValidationErrorFor(customer => customer.Email)
            .WithErrorMessage("Invalid email format.");
    }
    
    [Fact]
    public void Should_Have_Error_When_Symbol_Is_In_Beginning()
    {
        // Arrange
        var customerDto = new CustomerInputDTO { Email = "@test.com" };
        
        // Act & Action
        var result = _validator.TestValidate(customerDto);
        result.ShouldHaveValidationErrorFor(customer => customer.Email)
            .WithErrorMessage("Invalid email format.");
    }
    
    [Fact]
    public void Should_Have_Error_When_Symbol_Is_In_End()
    {
        // Arrange
        var customerDto = new CustomerInputDTO { Email = "@test.com" };
        
        // Act & Action
        var result = _validator.TestValidate(customerDto);
        result.ShouldHaveValidationErrorFor(customer => customer.Email)
            .WithErrorMessage("Invalid email format.");
    }
    
    [Fact]
    public void Should_Not_Have_Error_When_Email_Is_Valid()
    {
        // Arrange
        var customerDto = new CustomerInputDTO { Email = "test@test.com" };
        
        // Act & Assert
        var result = _validator.TestValidate(customerDto);
        result.ShouldNotHaveValidationErrorFor(customer => customer.Email);
    }
    
}