using Calculator.Core.Operators;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Operators
{
    public class MultiplyOperatorTests : MockBase<MultiplyOperator>
    {
        [TestCase(2, 3, 6)]
        public void Convert_StringIsValid_ReturnsCorrectOperationType(decimal testInputOperand1,
                                                                      decimal testInputOperand2,
                                                                      decimal expectedResult)
        {
            // Arrange
            
            // Act
            var result = Subject.Operate(testInputOperand1, testInputOperand2);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}