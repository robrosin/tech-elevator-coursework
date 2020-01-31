using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTests
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, false)]
        [DataRow(new int[] { 1, 2, 3, 1 }, true)]
        [DataRow(new int[] { 1, 2, 1 }, true)]

        public void IsItTheSame(int[] nums, bool expected)
        {
            SameFirstLast ex = new SameFirstLast();

            bool actualResult = ex.IsItTheSame(nums);

            Assert.AreEqual(expected, actualResult);
        }
    }
}