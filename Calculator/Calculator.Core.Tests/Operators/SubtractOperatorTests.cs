using Calculator.Core.Operators;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Operators
{
    public class SubtractOperatorTests : MockBase<SubtractOperator>
    {
        [TestCase(7, 2, 5)]
        [TestCase(1, -0.1, 1.1)]
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