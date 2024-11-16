using System.Threading.Tasks;
using FluentValidation.Results;
using GraphOfOrders.Lib.DTOs;

namespace GraphOfOrders.Lib.DI.Validator
{
    public interface IEmailValidator
    {
        Task<ValidationResult> ValidateEmail(CustomerInputDTO customer);
    }
}