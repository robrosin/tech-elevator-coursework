using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class KataFizzBuzzTests
    {
        [TestMethod]
        public void One_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();

            // Act
            string result = sum.fizzBuzz(1);

            // Assert
            Assert.AreEqual("1", result);
        }
        [TestMethod]
        public void OneHundred_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();

            // Act
            string result = sum.fizzBuzz(100);

            // Assert
            Assert.AreEqual("100", result);
        }
        [TestMethod]
        public void Fizz_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();
            // Add
            string result = sum.fizzBuzz(3);

            // Arrange
            Assert.AreEqual("Fizz", result);
        }
        [TestMethod]
        public void Buzz_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();
            // Add
            string result = sum.fizzBuzz(5);

            // Arrange
            Assert.AreEqual("Buzz", result);

        }
        [TestMethod]
        public void FizzBuzz_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();
            // Add
            string result = sum.fizzBuzz(15);

            // Arrange
            Assert.AreEqual("FizzBuzz", result);

        }
        [TestMethod]
        public void Outlier_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();
            // Add
            string result = sum.fizzBuzz(22);

            // Arrange
            Assert.AreEqual("22", result);

        }
        [TestMethod]
        public void Zero_FizzBuzzTest()
        {
            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz();

            // Add
            string result = sum.fizzBuzz(0);

            // Arrange
            Assert.AreEqual("", result);
        }
    }
}
