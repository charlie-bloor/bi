using Calculator.Core.Services;
using FluentAssertions;
using NUnit.Framework;
using TestUtilities;

namespace Calculator.Core.Tests.Services
{
    public class LineCountServiceTests : MockBase<LineCountService>
    {
        [Test]
        public void LineCount_HasNotBeenIncremented_Returns0()
        {
            // Arrange

            // Act
            var result = Subject.LineCount;

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void LineCount_HasBeenIncrementedOnce_Returns1()
        {
            // Arrange
            Subject.IncrementLineCount();

            // Act
            var result = Subject.LineCount;

            // Assert
            result.Should().Be(1);
        }

        [Test]
        public void LineCount_HasBeenIncrementedTwice_Returns2()
        {
            // Arrange
            Subject.IncrementLineCount();
            Subject.IncrementLineCount();

            // Act
            var result = Subject.LineCount;

            // Assert
            result.Should().Be(2);
        }
    }
}