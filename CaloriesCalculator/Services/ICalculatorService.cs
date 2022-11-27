using System.Threading.Tasks;
using CaloriesCalculator.Protos;
using Grpc.Core;

namespace CaloriesCalculator.Services
{
    interface ICalculatorService
    {
        Task<CalculateBasicReply> CalculateBasic(CalculateBasicRequest request, ServerCallContext context);
        Task<CalculateTotalReply> CalculateTotal(CalculateBasicRequest request, ServerCallContext context);
    }
}