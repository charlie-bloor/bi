using Calculator.Core.Exceptions;

namespace Calculator.Core.Converters
{
    public interface IStringToOperandConverter
    {
        decimal Convert(string value);
    }

    public class StringToOperandConverter : IStringToOperandConverter
    {
        public decimal Convert(string value)
        {
            if (decimal.TryParse(value, out var result))
            {
                return result;
            }
            
            throw new InvalidInputFileException($"Unable to convert value '{value}' to decimal");
        }
    }
}