using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class Less20Tests
    {
        [DataTestMethod]
        [DataRow(18, true)]
        [DataRow(19, true)]
        [DataRow(20, false)]

        public void Less20(int n, bool expected)
        {
            Less20 ex = new Less20();

            bool actualResult = ex.IsLessThanMultipleOf20(n);

            Assert.AreEqual(expected, actualResult);
        }
    }
}