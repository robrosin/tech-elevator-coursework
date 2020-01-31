using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class StringBitsTests
    {
        [DataTestMethod]
        [DataRow("Hello", "Hlo")]
        [DataRow("Hi", "H")]
        [DataRow("Heeololeo", "Hello")]

        public void GetBits(string str, string expected)
        {
            StringBits ex = new StringBits();

            string actualResult = ex.GetBits(str);

            Assert.AreEqual(expected, actualResult);
        }
    }
}