using Calculator.Core.Exceptions;

namespace Calculator.Core.Converters
{
    public interface IStringToOperationTypeConverter
    {
        OperationType Convert(string value);
    }

    public class StringToOperationTypeConverter : IStringToOperationTypeConverter
    {
        public OperationType Convert(string value)
        {
            switch (value)
            {
                case "apply":
                case "add":
                    return OperationType.Add;
                case "divide":
                    return OperationType.Divide;
                case "multiply":
                    return OperationType.Multiply;
                case "subtract":
                    return OperationType.Subtract;
                default:
                    throw new InvalidInputFileException($"Unknown operation '{value}'");
            }
        }
    }
}