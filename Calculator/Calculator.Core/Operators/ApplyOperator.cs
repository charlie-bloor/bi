using System;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// Represents the final instruction  to "Start with the number n".
    /// Therefore behaves like an addition operator whose left operand is expected to be zero.
    /// </summary>
    public class ApplyOperator : IOperator
    {
        public OperationType OperationType => OperationType.Apply;

        public decimal Operate(decimal leftOperand, decimal rightOperand)
        {
            if (leftOperand != 0)
            {
                throw new ArgumentException("The Apply operator expects to start with zero", nameof(leftOperand));
            }
            
            return rightOperand;
        }
    }
}