namespace Calculator.Core.Operators
{
    public class DivideOperator : IOperator
    {
        public OperationType OperationType => OperationType.Divide;

        public decimal Operate(decimal leftOperand, decimal rightOperand)
        {
            return leftOperand / rightOperand;
        }
    }
}