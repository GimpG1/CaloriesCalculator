using System.Data;
using CaloriesCalculator.Protos;
using FluentValidation;

namespace CaloriesCalculator.Validations
{
    internal class CalculateRequestValidator : AbstractValidator<CalculateBasicRequest>
    {
        public CalculateRequestValidator()
        {
            RuleFor(request => request.Weight).NotEmpty().GreaterThan(10f).LessThan(600f);
            RuleFor(request => request.Height).NotEmpty().GreaterThan(5f).LessThan(250f);
            RuleFor(request => request.Age).NotEmpty().GreaterThan((uint)1).LessThan((uint)130);
            RuleFor(request => request.Orientation).NotEmpty().IsInEnum();
            RuleFor(request => request.Activity).NotEmpty().IsInEnum();
        }
    }
}