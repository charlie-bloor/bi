using System;
using Calculator.Core.Exceptions;

namespace Calculator.Core.Operators
{
    public class DivideOperator : IOperator
    {
        public OperationType OperationType => OperationType.Divide;

        public decimal Operate(decimal leftOperand, decimal rightOperand)
        {
            if (rightOperand == 0)
            {
                throw new InvalidInputFileException("Cannot divide by zero");
            }

            return leftOperand / rightOperand;
        }
    }
}