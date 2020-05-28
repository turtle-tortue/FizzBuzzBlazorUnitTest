using Blazor_FizzBuzz.Components;
using System;
using Xunit;

namespace Blazor_FizzBuzzUnitTests
{
    public class BaseFizzBuzzComponentUnitTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void ReachedIterationEnd_FirstAndLastIterations_ReturnsTrue(int iterationStep)
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            var maxIterations = testBaseFizzBuzzComponent.GetMaximumNumberOfIterations();
            testBaseFizzBuzzComponent.SetIterator(iterationStep);

            // Act
            var isReachedIterationEnd = testBaseFizzBuzzComponent.ReachedIterationEnd();

            // Assert
            Assert.False(isReachedIterationEnd);
        }

        [Fact]
        public void ReachedIterationEnd_OutsideIteration_ReturnsFalse()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            var maxIterationsPlusOne = testBaseFizzBuzzComponent.GetMaximumNumberOfIterations() + 1;
            testBaseFizzBuzzComponent.SetIterator(maxIterationsPlusOne);

            // Act
            var isReachedIterationEnd = testBaseFizzBuzzComponent.ReachedIterationEnd();

            // Assert
            Assert.True(isReachedIterationEnd);
        }

        [Fact]
        public void IncrementIterator_OneToTwo_ReturnsTwo()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            testBaseFizzBuzzComponent.SetIterator(1);

            // Act
            testBaseFizzBuzzComponent.IncrementIterator();

            // Assert
            Assert.Equal(2, testBaseFizzBuzzComponent.GetCurrentIterator());
        }

        [Fact]
        public void GetCurrentIterator_InitializedToOne_ReturnsOne()
        {
            // Arrange & Act
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();

            // Assert
            Assert.Equal(1, testBaseFizzBuzzComponent.GetCurrentIterator());
        }

        [Fact]
        public void SetIterator_InitializedToOne_ReturnsOne()
        {
            // Arrange & Act
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();

            // Assert
            Assert.Equal(1, testBaseFizzBuzzComponent.GetCurrentIterator());
        }

        // GetStateString

        // SetCurrentState

        // GetMaximumNumberOfIterations

        // TextToPrint

        [Fact]
        public void TextToPrint__()
        {

        }
    }
}
