namespace Calculator.Core.Operators
{
    public class SubtractOperator : IOperator
    {
        public OperationType OperationType => OperationType.Subtract;

        public decimal Operate(decimal operand1, decimal operand2)
        {
            return operand1 - operand2;
        }
    }
}