using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class Lucky13Tests
    {
        [DataTestMethod]
        [DataRow(new int[] { 0, 2, 4 }, true)]
        [DataRow(new int[] { 1, 2, 3 }, false)]
        [DataRow(new int[] {1, 2, 4}, false)]

        public void GetLucky(int[] nums, bool expected)
        {
            Lucky13 ex = new Lucky13();

            bool actualResult = ex.GetLucky(nums);

            Assert.AreEqual(expected, actualResult);
        }
    }
}