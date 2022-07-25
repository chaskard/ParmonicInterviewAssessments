using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTesting.Tests
{
    public class FizzBuzzTests
    {
        [Fact()]
        public void FizzBuzzTests_Given1_Expect1()
        {
            // Arrange
            var objFizzBuzz = new FizzBuzz();
            var expected = 1;

            // Act
            var actual = objFizzBuzz.GetFizzBuzzResult(1);

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact()]
        public void FizzBuzzTests_Given3_ExpectFizz()
        {
            // Arrange
            var objFizzBuzz = new FizzBuzz();
            var expected = "Fizz";

            // Act
            var actual = objFizzBuzz.GetFizzBuzzResult(3);

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact()]
        public void FizzBuzzTests_Given5_ExpectBuzz()
        {
            // Arrange
            var objFizzBuzz = new FizzBuzz();
            var expected = "Buzz";

            // Act
            var actual = objFizzBuzz.GetFizzBuzzResult(5);

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact()]
        public void FizzBuzzTests_Given15_ExpectFizzBuzz()
        {
            // Arrange
            var objFizzBuzz = new FizzBuzz();
            var expected = "FizzBuzz";

            // Act
            var actual = objFizzBuzz.GetFizzBuzzResult(15);

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FizzBuzzTests_Given0_ExpectException()
        {
            // Arrange
            var objFizzBuzz = new FizzBuzz();

            // Act
            objFizzBuzz.GetFizzBuzzResult(15);
        }
    }
}