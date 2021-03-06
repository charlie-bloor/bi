using System.Collections.Generic;
using System.Threading.Tasks;
using Calculator.Core.Operators;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Services
{
    public class CalculatorTests : MockBase<Core.Services.Calculator>
    {
        protected override void SetUp()
        {
            // For these tests, use the real dependencies rather than mocked ones.
            // We could mock them, but it's simpler not to and allows for greater confidence
            // that we can calculate the result.
            Mocker.Use<IEnumerable<IOperator>>(new List<IOperator>
            {
                new AddOperator(),
                new ApplyOperator(),
                new DivideOperator(),
                new MultiplyOperator(),
                new SubtractOperator()
            });

            base.SetUp();
        }

        [Test]
        public async Task CalculateResultAsync_InputIsTestCase1_ReturnsExpectedResult()
        {
            // Arrange
            static async IAsyncEnumerable<Operation> GetTestInputAsync()
            {
                yield return await Task.FromResult(new Operation(3, OperationType.Apply));
                yield return await Task.FromResult(new Operation(2, OperationType.Add));
                yield return await Task.FromResult(new Operation(3, OperationType.Multiply));
            }

            // Act
            var result = await Subject.CalculateResultAsync(GetTestInputAsync());

            // Assert
            result.Should().Be(15);
        }

        [Test]
        public async Task CalculateResultAsync_InputIsTestCase2_ReturnsExpectedResult()
        {
            // Arrange
            static async IAsyncEnumerable<Operation> GetTestInputAsync()
            {
                yield return await Task.FromResult(new Operation(5, OperationType.Apply));
                yield return await Task.FromResult(new Operation(9, OperationType.Multiply));
            }

            // Act
            var result = await Subject.CalculateResultAsync(GetTestInputAsync());

            // Assert
            result.Should().Be(45);
        }
    }
}