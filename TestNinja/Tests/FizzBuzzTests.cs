using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class FizzBuzzTests
    {
        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(30);
            Assert.AreEqual(result, "FizzBuzz");
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(21);
            Assert.AreEqual(result, "Fizz");
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(10);
            Assert.AreEqual(result, "Buzz");
        }

        [Test]
        public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnsNumberToString()
        {
            var result = FizzBuzz.GetOutput(16);
            Assert.AreEqual(result, "16");
        }

        [Test]
        public void GetOutput_InputIsZero_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(0);
            Assert.AreEqual(result, "FizzBuzz");
        }
    }
}
