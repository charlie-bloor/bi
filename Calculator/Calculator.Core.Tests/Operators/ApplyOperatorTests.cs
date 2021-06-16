using System;
using Calculator.Core.Operators;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Operators
{
    public class ApplyOperatorTests : MockBase<ApplyOperator>
    {
        [TestCase(0, 3, 3)]
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

        [TestCase(-1)]
        [TestCase(1)]
        public void Operate_LeftOperandIsNotZero_ThrowsArgumentException(decimal testInputLeftOperand)
        {
            // Arrange

            // Act
            Action act = () => Subject.Operate(testInputLeftOperand, default);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}