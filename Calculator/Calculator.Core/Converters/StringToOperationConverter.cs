using Calculator.Core.Exceptions;

namespace Calculator.Core.Converters
{
    public interface IStringToOperationConverter
    {
        Operation Convert(string value);
    }

    /// <summary>
    /// Creates a strongly-typed <see cref="Operation"/> from text such as "add 2"
    /// </summary>
    public class StringToOperationConverter : IStringToOperationConverter
    {
        private readonly IStringToOperandConverter _stringToOperandConverter;
        private readonly IStringToOperationTypeConverter _stringToOperationTypeConverter;

        public StringToOperationConverter(IStringToOperandConverter stringToOperandConverter,
                                          IStringToOperationTypeConverter stringToOperationTypeConverter)
        {
            _stringToOperandConverter = stringToOperandConverter;
            _stringToOperationTypeConverter = stringToOperationTypeConverter;
        }
        
        public Operation Convert(string value)
        {
            value = value.Trim();
            
            // International decimal formats can include commas, spaces or both.
            var indexOfFirstSpace = value.IndexOf(' ');

            if (indexOfFirstSpace == -1)
            {
                throw new InvalidInputFileException("No space character was found");
            }

            // Because we've already trimmed the input text, we know that indexOfFirstSpace > zero.
            var operationName = value.Substring(0, indexOfFirstSpace);
            var operationType = _stringToOperationTypeConverter.Convert(operationName);

            var operandStartIndex = indexOfFirstSpace + 1;
            var remainingCharacters = value.Length - operandStartIndex;
            var operandTextInFile = value.Substring(operandStartIndex, remainingCharacters);
            var operand = _stringToOperandConverter.Convert(operandTextInFile);
            return new Operation(operand, operationType);
        }
    }
}