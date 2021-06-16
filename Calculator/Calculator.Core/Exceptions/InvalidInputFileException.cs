using System;

namespace Calculator.Core.Exceptions
{
    public class InvalidInputFileException : Exception
    {
        public InvalidInputFileException(string message) : base(message)
        {
        }
    }
}