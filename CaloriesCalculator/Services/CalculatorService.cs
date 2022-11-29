using CaloriesCalculator.Protos;
using CaloriesCalculator.Structure;
using CaloriesCalculator.Structure.Calculations;
using CaloriesCalculator.Structure.Operations;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CaloriesCalculator.Services
{
    public sealed class CalculatorService : Calculator.CalculatorBase, ICalculatorService
    {
        private readonly ILogger<CalculatorService> _logger;
        private readonly IActivity _activity;
        public CalculatorService(ILogger<CalculatorService> logger, IActivity activity)
        {
            _logger = logger;
            _activity = activity ?? throw new ArgumentNullException(nameof(activity));
        }

        public override async Task<CalculateTotalReply> CalculateTotal(CalculateBasicRequest request, ServerCallContext context)
        {
            var calculationDataBase = CreateBaseCalculationFor(request.Orientation, _activity);
            //TODO: add the validations for request in here
            if (calculationDataBase is EmptyCalculations)
            {
                return await Task.FromResult(new CalculateTotalReply()
                {
                    Basic = 0,
                    Total = 0,
                    Message = "Couldn't make proper calculations according to requested type",
                    State = ReadingStatus.Failure
                });
            }

            var calculator = new Calculate(calculationDataBase);
            calculator.CalculateBasicMetabolism(request)
                      .CalculateTotalMetabolism(request.Activity, request.Orientation);

            return await Task.FromResult(new CalculateTotalReply()
            {
                Basic = calculator.BasicMetabolism,
                Total = calculator.TotalMetabolism,
                Message = string.Format("Calculated for: {0}, with activity level at {1}", request.Orientation, request.Activity),
                State = ReadingStatus.Success
            });
        }

        private BaseCalculationData CreateBaseCalculationFor(SexOrientation orientation, IActivity activity)
        {
            return orientation switch
            {
                SexOrientation.Female => new FemaleCalculationData(activity),
                SexOrientation.Male => new MaleCalculationData(activity),
                _ => new EmptyCalculations(activity),
            };
        }
    }
}
