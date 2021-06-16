namespace Calculator.Core.Operators
{
    public class NoOperationOperator : IOperator
    {
        public OperationType OperationType => OperationType.None;

        public decimal Operate(decimal operand)
        {
            throw new System.NotImplementedException();
        }
    }
}