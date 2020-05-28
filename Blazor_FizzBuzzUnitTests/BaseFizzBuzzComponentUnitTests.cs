using Blazor_FizzBuzz.Components;
using Blazor_FizzBuzz.Data;
using Microsoft.AspNetCore.Components.Testing;
using System;
using Xunit;

namespace Blazor_FizzBuzzUnitTests
{
    public class BaseFizzBuzzComponentUnitTests
    {
        #region FUNCTIONAL UNIT TESTS

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
            var resultIsReachedIterationEnd = testBaseFizzBuzzComponent.ReachedIterationEnd();

            // Assert
            Assert.False(resultIsReachedIterationEnd);
        }

        [Fact]
        public void ReachedIterationEnd_OutsideIteration_ReturnsFalse()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            var maxIterationsPlusOne = testBaseFizzBuzzComponent.GetMaximumNumberOfIterations() + 1;
            testBaseFizzBuzzComponent.SetIterator(maxIterationsPlusOne);

            // Act
            var resultIsReachedIterationEnd = testBaseFizzBuzzComponent.ReachedIterationEnd();

            // Assert
            Assert.True(resultIsReachedIterationEnd);
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

        [Fact]
        public void GetStateString_NonDivisibleByThreeOrFive_ReturnsNumber()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            testBaseFizzBuzzComponent.SetIterator(1);

            // Act
            var resultFizzBuzzComponentClass = testBaseFizzBuzzComponent.GetStateString();

            // Assert
            Assert.Equal("Number", resultFizzBuzzComponentClass);
        }

        [Fact]
        public void GetStateString_DivisibleByThreeOnly_ReturnsFizz()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            testBaseFizzBuzzComponent.SetIterator(3);

            // Act
            var resultFizzBuzzComponentClass = testBaseFizzBuzzComponent.GetStateString();

            // Assert
            Assert.Equal("Fizz", resultFizzBuzzComponentClass);
        }

        [Fact]
        public void GetStateString_DivisibleByFiveOnly_ReturnsBuzz()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            testBaseFizzBuzzComponent.SetIterator(5);

            // Act
            var resultFizzBuzzComponentClass = testBaseFizzBuzzComponent.GetStateString();

            // Assert
            Assert.Equal("Buzz", resultFizzBuzzComponentClass);
        }

        [Fact]
        public void GetStateString_DivisibleByThreeAndFive_ReturnsFizzBuzz()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            testBaseFizzBuzzComponent.SetIterator(15);

            // Act
            var resultFizzBuzzComponentClass = testBaseFizzBuzzComponent.GetStateString();

            // Assert
            Assert.Equal("FizzBuzz", resultFizzBuzzComponentClass);
        }

        [Fact]
        public void GetMaximumNumberOfIterations_Returns100()
        {
            // Arrange & Act
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();

            // Assert
            Assert.Equal(100, testBaseFizzBuzzComponent.GetMaximumNumberOfIterations());
        }

        [Fact]
        public void TextToPrint_NonDivisibleByThreeOrFive_ReturnsStringValue()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            testBaseFizzBuzzComponent.SetIterator(1);

            // Act
            var resultFizzBuzzTextToPrint = testBaseFizzBuzzComponent.TextToPrint();

            // Assert
            Assert.Equal("1", resultFizzBuzzTextToPrint);
        }

        [Fact]
        public void TextToPrint_DivisibleByThreeOnly_ReturnsStringFizz()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            testBaseFizzBuzzComponent.SetIterator(3);

            // Act
            var resultFizzBuzzTextToPrint = testBaseFizzBuzzComponent.GetStateString();

            // Assert
            Assert.Equal("Fizz", resultFizzBuzzTextToPrint);
        }

        [Fact]
        public void TextToPrint_DivisibleByFiveOnly_ReturnsStringBuzz()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            testBaseFizzBuzzComponent.SetIterator(5);

            // Act
            var resultFizzBuzzTextToPrint = testBaseFizzBuzzComponent.GetStateString();

            // Assert
            Assert.Equal("Buzz", resultFizzBuzzTextToPrint);
        }

        [Fact]
        public void TextToPrint_DivisibleByThreeAndFive_ReturnsStringFizzBuzz()
        {
            // Arrange
            var testBaseFizzBuzzComponent = new BaseFizzBuzzComponent();
            testBaseFizzBuzzComponent.SetIterator(15);

            // Act
            var resultFizzBuzzTextToPrint = testBaseFizzBuzzComponent.GetStateString();

            // Assert
            Assert.Equal("FizzBuzz", resultFizzBuzzTextToPrint);
        }

        #endregion FUNCTIONAL UNIT TESTS

        #region BEHAVIORAL UNIT TESTS
        
        [Fact]
        public void BaseFizzBuzzComponentClass_NonDivisibleByThreeOrFive_ReturnsNumber()
        {
            // Arrange & Act
            TestHost testHost = new TestHost();
            var testBaseFizzBuzzRenderedComponent = testHost.AddComponent<BaseFizzBuzzComponent>();

            foreach (HtmlAgilityPack.HtmlNode paragrapItem in testBaseFizzBuzzRenderedComponent.FindAll("p"))
            {
                if (paragrapItem.Attributes["class"].Value.Contains("Number-1"))
                { 
                    // Assert
                    Assert.Equal("Number Number-1", paragrapItem.Attributes["class"].Value);
                    break;
                }      
            }
        }

        [Fact]
        public void BaseFizzBuzzComponentClass_DivisibleByThreeOnly_ReturnsStringFizz()
        {
            // Arrange & Act
            TestHost testHost = new TestHost();
            var testBaseFizzBuzzRenderedComponent = testHost.AddComponent<BaseFizzBuzzComponent>();

            foreach (HtmlAgilityPack.HtmlNode paragrapItem in testBaseFizzBuzzRenderedComponent.FindAll("p"))
            {
                if (paragrapItem.Attributes["class"].Value.Contains("Number-3"))
                {
                    // Assert
                    Assert.Equal("Fizz Number-3", paragrapItem.Attributes["class"].Value);
                    break;
                }
            }
        }

        [Fact]
        public void BaseFizzBuzzComponentClass_DivisibleByFiveOnly_ReturnsStringBuzz()
        {
            // Arrange & Act
            TestHost testHost = new TestHost();
            var testBaseFizzBuzzRenderedComponent = testHost.AddComponent<BaseFizzBuzzComponent>();

            foreach (HtmlAgilityPack.HtmlNode paragrapItem in testBaseFizzBuzzRenderedComponent.FindAll("p"))
            {
                if (paragrapItem.Attributes["class"].Value.Contains("Number-5"))
                {
                    // Assert
                    Assert.Equal("Buzz Number-5", paragrapItem.Attributes["class"].Value);
                    break;
                }
            }
        }

        [Fact]
        public void BaseFizzBuzzComponentClass_DivisibleByThreeAndFive_ReturnsStringFizzBuzz()
        {
            // Arrange & Act
            TestHost testHost = new TestHost();
            var testBaseFizzBuzzRenderedComponent = testHost.AddComponent<BaseFizzBuzzComponent>();

            foreach (HtmlAgilityPack.HtmlNode paragrapItem in testBaseFizzBuzzRenderedComponent.FindAll("p"))
            {
                if (paragrapItem.Attributes["class"].Value.Contains("Number-15"))
                {
                    // Assert
                    Assert.Equal("FizzBuzz Number-15", paragrapItem.Attributes["class"].Value);
                    break;
                }
            }
        }
        
        #endregion BEHAVIORAL UNIT TESTS
    }
}
