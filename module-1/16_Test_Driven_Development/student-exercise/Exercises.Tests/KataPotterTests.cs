using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class KataPotterTests
    {
        [TestMethod]
        public void OneBook_CostFirstTest()
        {
            // Arrange
            GetCostTest sum = new GetCostTest();

            // Act
            string result = sum.NumberOfBooks(8.00);

            // Assert
            Assert.AreEqual("8.00", result);
        }
        [TestMethod]
        public void TwoBook_CostFirstTest()
        {
            // Arrange
            GetCostTest sum = new GetCostTest();

            // Act
            string result = sum.NumberOfBooks(2);

            // Assert
            Assert.AreEqual("15.20", result);
        }
        [TestMethod]
        public void ThreeBook_CostFirstTest()
        {
            // Arrange
            GetCostTest sum = new GetCostTest();

            // Act
            string result = sum.NumberOfBooks(3);

            // Assert
            Assert.AreEqual("21.60", result);
        }
        [TestMethod]
        public void FourBook_CostFirstTest()
        {
            // Arrange
            GetCostTest sum = new GetCostTest();

            // Act
            string result = sum.NumberOfBooks(4);

            // Assert
            Assert.AreEqual("25.60", result);
        }
        [TestMethod]
        public void FiveBook_CostFirstTest()
        {
            // Arrange
            GetCostTest sum = new GetCostTest();

            // Act
            string result = sum.NumberOfBooks(5);

            // Assert
            Assert.AreEqual("30.00", result);
        }
    }
    internal class GetCostTest
    {
        internal string NumberOfBooks(double v)
        {
            throw new NotImplementedException();
        }
    }
}
