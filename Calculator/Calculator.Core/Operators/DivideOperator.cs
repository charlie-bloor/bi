namespace Calculator.Core.Operators
{
    public class DivideOperator : IOperator
    {
        public OperationType OperationType => OperationType.Divide;

        public decimal Operate(decimal operand1, decimal operand2)
        {
            return operand1 / operand2;
        }
    }
}