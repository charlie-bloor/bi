namespace Calculator.Core.Operators
{
    public class NoOperationOperator : IOperator
    {
        public OperationType OperationType => OperationType.None;

        public decimal Operate(decimal operand1, decimal operand2)
        {
            throw new System.NotImplementedException();
        }
    }
}