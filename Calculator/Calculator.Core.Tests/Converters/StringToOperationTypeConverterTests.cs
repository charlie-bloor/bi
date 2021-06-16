using System;
using Calculator.Core.Converters;
using Calculator.Core.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Converters
{
    public class StringToOperationTypeConverterTests : MockBase<StringToOperationTypeConverter>
    {
        [TestCase("add", OperationType.Add)]
        [TestCase("apply", OperationType.Apply)]
        [TestCase("divide", OperationType.Divide)]
        [TestCase("multiply", OperationType.Multiply)]
        [TestCase("subtract", OperationType.Subtract)]
        public void Convert_StringIsValid_ReturnsCorrectOperationType(string testInputText, OperationType expectedOperationType)
        {
            // Arrange
            
            // Act
            var result = Subject.Convert(testInputText);

            // Assert
            result.Should().Be(expectedOperationType);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("garbage")]
        public void Convert_StringIsNotValid_ThrowsException(string testInputText)
        {
            // Arrange
            var expectedMessage = $"Unknown operation '{testInputText}'";
            
            // Act
            Action act = () => Subject.Convert(testInputText);

            // Assert
            act.Should().Throw<InvalidInputFileException>().Where(e => e.Message == expectedMessage);
        }
    }
}