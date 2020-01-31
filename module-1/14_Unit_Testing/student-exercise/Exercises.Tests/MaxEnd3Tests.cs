using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class MaxEnd3Tests
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 3, 3 })]
        [DataRow(new int[] { 11, 5, 9 }, new int[] { 11, 11, 11 })]
        [DataRow(new int[] { 2, 11, 3 }, new int[] { 3, 3, 3 })]

        public void MakeArray(int[] nums, int[] expected)
        {
            MaxEnd3 ex = new MaxEnd3();

            int[] actualResult = ex.MakeArray(nums);

            CollectionAssert.AreEqual(expected, actualResult);
        }
    }
}