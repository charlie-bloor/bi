namespace Calculator.Core.Operators
{
    public class AddOperator : IOperator
    {
        public OperationType OperationType => OperationType.Add;

        public decimal Operate(decimal operand)
        {
            throw new System.NotImplementedException();
        }
    }
}