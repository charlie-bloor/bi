using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Core.Operators;

namespace Calculator.Core
{
    public interface ICalculator
    {
        Task<decimal> CalculateResultAsync(IAsyncEnumerable<Operation> orderedOperations);
    }

    public class Calculator : ICalculator
    {
        private readonly IEnumerable<IOperator> _operators;

        public Calculator(IEnumerable<IOperator> operators)
        {
            _operators = operators;
        }
        
        public async Task<decimal> CalculateResultAsync(IAsyncEnumerable<Operation> orderedOperations)
        {
            decimal result = 0;

            await foreach (var operation in orderedOperations)
            {
                var @operator = _operators.Single(o => o.OperationType == operation.OperationType);
                result = @operator.Operate(result, operation.Operand);
            }

            return result;
        }
    }
}