using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class KataFizzBuzzTestsPart2
    {
        [TestMethod]
        public void Three_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();

            // Act
            string result = sum.fizzBuzz(3);

            // Assert
            Assert.AreEqual("Fizz", result);
        }
        [TestMethod]
        public void Thirteen_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();

            // Act
            string result = sum.fizzBuzz(13);

            // Assert
            Assert.AreEqual("Fizz", result);
        }
        [TestMethod]
        public void ThirtyFive_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();

            // Act
            string result = sum.fizzBuzz(35);

            // Assert
            Assert.AreEqual("FizzBuzz", result);
        }
        [TestMethod]
        public void Five_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();

            // Act
            string result = sum.fizzBuzz(5);

            // Assert
            Assert.AreEqual("Buzz", result);
        }
        [TestMethod]
        public void FiftyOne_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();

            // Act
            string result = sum.fizzBuzz(51);

            // Assert
            Assert.AreEqual("Buzz", result);
        }
        [TestMethod]
        public void FiftyThree_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();

            // Act
            string result = sum.fizzBuzz(53);

            // Assert
            Assert.AreEqual("FizzBuzz", result);
        }
    }
}
