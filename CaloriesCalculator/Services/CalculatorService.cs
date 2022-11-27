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

        public override async Task<CalculateBasicReply> CalculateBasic(CalculateBasicRequest request, ServerCallContext context)
        {
            var calculationDataBase = CreateBaseCalculationFor(request.Orientation, _activity);
            if (calculationDataBase is EmptyCalculations)
            {
                return await Task.FromResult(new CalculateBasicReply()
                {
                    Basic = 0.0f,
                    Message = "Couldn't make proper calculations according to requested type",
                    State = ReadingStatus.Failure
                });
            }

            var calculator = new Calculate(calculationDataBase);
            return await Task.FromResult(new CalculateBasicReply()
            {
                Basic = calculator.CalculatePpm(request),
                Message = "Calculated for request",
                State = ReadingStatus.Success
            });
        }

        public override async Task<CalculateTotalReply> CalculateTotal(CalculateBasicRequest request, ServerCallContext context)
        {
            var calculationDataBase = CreateBaseCalculationFor(request.Orientation, _activity);
            if (calculationDataBase is EmptyCalculations)
            {
                return await Task.FromResult(new CalculateTotalReply()
                {
                    Total = 0.0f,
                    Message = "Couldn't make proper calculations according to requested type",
                    State = ReadingStatus.Failure
                });
            }

            var calculator = new Calculate(calculationDataBase);
            calculator.CalculatePpm(request);
            calculator.CalculateCpm(request.Activity, request.Orientation, out var total);
            return await Task.FromResult(new CalculateTotalReply()
            {
                Total = total,
                Message = "Calculated for request",
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
