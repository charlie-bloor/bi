using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Core.Operators;

namespace Calculator.Core
{
    /// <summary>
    /// Calculates the result of supplied operations
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Calculate the result of the supplied operations
        /// </summary>
        /// <returns>The total, having performed all of the supplied operations</returns>
        /// <remarks>
        /// In the supplied operations, the "apply" operation must appear as the first operation, and once only.
        /// </remarks>
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
            decimal runningTotal = 0;

            await foreach (var operation in orderedOperations)
            {
                var @operator = _operators.Single(o => o.OperationType == operation.OperationType);
                runningTotal = @operator.Operate(runningTotal, operation.Operand);
            }

            return runningTotal;
        }
    }
}