using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calzolari.Grpc.AspNetCore.Validation;
using FluentValidation.Results;

namespace CaloriesCalculator.Validations
{
    internal sealed class CalculateValidationHandler : IValidatorErrorMessageHandler
    {
        Task<string> IValidatorErrorMessageHandler.HandleAsync(IList<ValidationFailure> failures)
        {
            var errors = failures
                .Select(f => $"Property {f.PropertyName} failed validation.")
                .ToList();
            errors.Add("Please try again with fixing the value.");

            return Task.FromResult(string.Join("\n", errors));
        }
    }
}