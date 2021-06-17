using System;
using System.Collections.Generic;
using Calculator.Core.Converters;
using Calculator.Core.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Converters
{
    public class StringToOperandConverterTests : MockBase<StringToOperandConverter>
    {
        [TestCaseSource(nameof(GetValidTestCases))]
        public void Convert_StringIsValid_ReturnsCorrectOperationType((string TestInputText, decimal ExpectedResult) testCase)
        {
            // Arrange
            
            // Act
            var result = Subject.Convert(testCase.TestInputText);

            // Assert
            result.Should().Be(testCase.ExpectedResult);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("Garbage")]
        public void Convert_StringIsNotValid_ReturnsCorrectOperationType(string testInputText)
        {
            // Arrange

            // Act
            Action act = () => Subject.Convert(testInputText);

            // Assert
            act.Should().Throw<InvalidInputFileException>();
        }

        private static IEnumerable<(string TestInputText, decimal ExpectedResult)> GetValidTestCases()
        {
            yield return ("9999999999999999999999999999", 9999999999999999999999999999m);
            yield return ("-9999999999999999999999999999", -9999999999999999999999999999m);
            yield return ("0.0000000000000000000000000001", 0.0000000000000000000000000001m);
            yield return ("-0.0000000000000000000000000001", -0.0000000000000000000000000001m);
        }
    }
}