using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTest
    {
        [DataTestMethod]
        [DataRow("Chocolate", 2, "ChoCho")]
        [DataRow("Chocolate", 3, "ChoChoCho")]
        [DataRow("Abc", 3, "AbcAbcAbc")]

        public void FrontTimes(string str, int n, string expected)
        {
            FrontTimes ex = new FrontTimes();

            string actualResult = ex.GenerateString(str, n);

            Assert.AreEqual(expected, actualResult);
        }
    }
}