using Calculator.Core.Operators;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Operators
{
    public class MultiplyOperatorTests : MockBase<MultiplyOperator>
    {
        [TestCase(2, 3, 6)]
        public void Operate_InputIsValid_ReturnsCorrectResult(decimal testInputLeftOperand,
                                                              decimal testInputRightOperand,
                                                              decimal expectedResult)
        {
            // Arrange
            
            // Act
            var result = Subject.Operate(testInputLeftOperand, testInputRightOperand);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}