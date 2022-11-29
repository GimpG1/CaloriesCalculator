using System.Threading.Tasks;
using CaloriesCalculator.Protos;
using Grpc.Core;

namespace CaloriesCalculator.Services
{
    interface ICalculatorService
    {
        Task<CalculateTotalReply> CalculateTotal(CalculateBasicRequest request, ServerCallContext context);
    }
}