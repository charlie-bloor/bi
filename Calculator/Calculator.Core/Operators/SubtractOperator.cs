namespace Calculator.Core.Operators
{
    public class SubtractOperator : IOperator
    {
        public OperationType OperationType => OperationType.Subtract;

        public decimal Operate(decimal leftOperand, decimal rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}