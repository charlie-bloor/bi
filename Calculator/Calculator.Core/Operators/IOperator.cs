namespace Calculator.Core.Operators
{
    public interface IOperator
    {
        OperationType OperationType { get; }
        decimal Operate(decimal leftOperand, decimal rightOperand);
    }
}