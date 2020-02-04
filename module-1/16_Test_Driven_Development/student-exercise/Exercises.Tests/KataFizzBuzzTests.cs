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
        public void OneFizzBuzzTest()
        {
            int number = 1;

            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz(number);

            // Add
            string result = sum.Add(number);

            // Assert
            Assert.AreEqual("1", result);
        }
        [TestMethod]
        public void FizzFizzBuzzTest()
        {
            int number = 3;

            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz(number);
            // Add
            string result = sum.Add(number);

            // Arrange
            Assert.AreEqual("Fizz", result);
        }
        public void BuzzFizzBuzzTest()
        {
            int number = 5;

            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz(number);
            // Add
            string result = sum.Add(number);

            // Arrange
            Assert.AreEqual("Buzz", result);

        }
        public void FizzBuzzFizzBuzzTest()
        {
            int number = 15;

            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz(number);
            // Add
            string result = sum.Add(number);

            // Arrange
            Assert.AreEqual("FizzBuzz", result);

        }
        public void OutlierFizzBuzzTest()
        {
            int number = 22;

            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz(number);
            // Add
            string result = sum.Add(number);

            // Arrange
            Assert.AreEqual("22", result);

        }
        public void ZeroFizzBuzzTest()
        {
            int number = 0;

            // Arrange
            KataFizzBuzz sum = new KataFizzBuzz(number);
            // Add
            string result = sum.Add(number);

            // Arrange
            Assert.AreEqual("", result);

        }
    }
}


}
