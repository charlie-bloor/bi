using System.Collections.Generic;
using Calculator.Core.Converters;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Converters
{
    public class StringToOperationConverterTests : MockBase<StringToOperationConverter>
    {
        [TestCaseSource(nameof(GetTestCases))]
        public void Convert_StringIsValid_ReturnsExpectedOperation((string TestInputText, Operation ExpectedResult) testCase)
        {
            // Arrange
            
            // Act
            var result = Subject.Convert(testCase.TestInputText);

            // Assert
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }

        protected override void SetUp()
        {
            // For these tests, use the real dependencies rather than mocked ones.
            // We could mock them, but it's simpler not to and allows for greater confidence
            // that we can convert a line from the file.
            Mocker.Use<IStringToOperandConverter>(new StringToOperandConverter());
            Mocker.Use<IStringToOperationTypeConverter>(new StringToOperationTypeConverter());
            base.SetUp();
        }

        private static IEnumerable<(string TestInputText, Operation ExpectedResult)> GetTestCases()
        {
            yield return ("apply 9999999999999999999999999999", new Operation(9999999999999999999999999999m, OperationType.Apply));
            yield return ("add -9999999999999999999999999999", new Operation(-9999999999999999999999999999m, OperationType.Add));
            yield return ("subtract 0.0000000000000000000000000001", new Operation(0.0000000000000000000000000001m, OperationType.Subtract));
            yield return ("divide -0.0000000000000000000000000001", new Operation(-0.0000000000000000000000000001m, OperationType.Divide));
            yield return ("multiply 123", new Operation(123m, OperationType.Multiply));
        }
    }
}