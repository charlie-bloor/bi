namespace Calculator.Core.Operators
{
    public class DivideOperator : IOperator
    {
        public OperationType OperationType => OperationType.Divide;

        public decimal Operate(decimal operand)
        {
            throw new System.NotImplementedException();
        }
    }
}