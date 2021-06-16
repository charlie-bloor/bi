namespace Calculator.Core
{
    public class Operation
    {
        public decimal Operand { get; }
        public OperationType OperationType { get; }

        public Operation(decimal operand, OperationType operationType)
        {
            Operand = operand;
            OperationType = operationType;
        }
    }
}