namespace Calculator.Core.Operators
{
    public class MultiplyOperator : IOperator
    {
        public OperationType OperationType => OperationType.Multiply;

        public decimal Operate(decimal leftOperand, decimal rightOperand)
        {
            return leftOperand * rightOperand;
        }
    }
}