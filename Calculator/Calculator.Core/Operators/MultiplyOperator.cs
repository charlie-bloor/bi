namespace Calculator.Core.Operators
{
    public class MultiplyOperator : IOperator
    {
        public OperationType OperationType => OperationType.Multiply;

        public decimal Operate(decimal operand1, decimal operand2)
        {
            return operand1 * operand2;
        }
    }
}