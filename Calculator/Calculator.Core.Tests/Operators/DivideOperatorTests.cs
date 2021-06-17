using System;
using Calculator.Core.Exceptions;
using Calculator.Core.Operators;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Operators
{
    public class DivideOperatorTests : MockBase<DivideOperator>
    {
        [TestCase(10, 5, 2)]
        [TestCase(5, -2, -2.5)]
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

        [Test]
        public void Operate_RightOperandIsZero_ThrowsException()
        {
            // Arrange
            var expectedMessage = "Cannot divide by zero";

            // Act
            Action act = () => Subject.Operate(1, 0);

            // Assert
            act.Should().Throw<InvalidInputFileException>().Where(e => e.Message == expectedMessage);
        }
    }
}