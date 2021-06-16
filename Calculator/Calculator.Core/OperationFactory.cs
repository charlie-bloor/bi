using Calculator.Core.Converters;
using Calculator.Core.Exceptions;

namespace Calculator.Core
{
    public interface IOperationFactory
    {
        Operation Create(string text);
    }

    /// <summary>
    /// Creates a strongly-typed <see cref="Operation"/> from text such as "add 2"
    /// </summary>
    public class OperationFactory : IOperationFactory
    {
        private readonly IStringToOperandConverter _stringToOperandConverter;
        private readonly IStringToOperationTypeConverter _stringToOperationTypeConverter;

        public OperationFactory(IStringToOperandConverter stringToOperandConverter,
                                IStringToOperationTypeConverter stringToOperationTypeConverter)
        {
            _stringToOperandConverter = stringToOperandConverter;
            _stringToOperationTypeConverter = stringToOperationTypeConverter;
        }
        
        public Operation Create(string text)
        {
            text = text.Trim();
            
            // International decimal formats can include commas, spaces or both
            // Get the name of the operation from the first
            var indexOfFirstSpace = text.IndexOf(' ');

            if (indexOfFirstSpace == -1)
            {
                throw new InvalidInputFileException("No space character was found");
            }

            // Because we've already trimmed the input text, we know that indexOfFirstSpace > zero.
            var operationName = text.Substring(0, indexOfFirstSpace);
            var operationType = _stringToOperationTypeConverter.Convert(operationName);

            var operandStartIndex = indexOfFirstSpace + 1;
            var remainingCharacters = text.Length - operandStartIndex;
            var operandTextInFile = text.Substring(operandStartIndex, remainingCharacters);
            var operand = _stringToOperandConverter.Convert(operandTextInFile);
            return new Operation(operand, operationType);
        }
    }
}