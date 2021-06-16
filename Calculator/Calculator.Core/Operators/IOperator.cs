namespace Calculator.Core.Operators
{
    public interface IOperator
    {
        OperationType OperationType { get; }
        decimal Operate(decimal operand1, decimal operand2);
    }
}