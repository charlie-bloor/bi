namespace Calculator.Core.Operators
{
    public class AddOperator : IOperator
    {
        public OperationType OperationType => OperationType.Add;

        public decimal Operate(decimal operand1, decimal operand2)
        {
            return operand1 + operand2;
        }
    }
}