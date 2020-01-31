using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTests
    {
        [DataTestMethod]
        [DataRow("Hello", "There", "ellohere")]
        [DataRow("java", "code", "avaode")]
        [DataRow("shotl", "java", "hotlava")]

        public void GetPartialstring(string a, string b, string expected)
        {
            NonStart ex = new NonStart();

            string  actualResult = ex.GetPartialString(a, b);

            Assert.AreEqual(expected, actualResult);
        }
    }
}