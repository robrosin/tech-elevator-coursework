using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTests
    {
        [DataTestMethod]
        [DataRow(5, 10, 2)]
        [DataRow(5, 2, 0)]
        [DataRow(5, 5, 1)]

        public void DateFashion(int you, int date, int expected)
        {
            DateFashion ex = new DateFashion();

            int actualResult = ex.GetATable(you, date);

            Assert.AreEqual(expected, actualResult);
        }
    }
}