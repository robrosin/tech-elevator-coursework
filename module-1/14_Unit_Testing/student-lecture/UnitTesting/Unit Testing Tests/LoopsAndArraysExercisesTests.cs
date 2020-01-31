using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testing_Tests
{
    [TestClass]
    public class LoopsAndArraysExercisesTests
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 2, 5 })]
        public void MiddleWayTests(int[] arrA, int[] arrB, int[] expectedResult)
        {
            LoopsAndArraysExercisesTests ex = new LoopsAndArraysExercisesTests();

            int[] actualResult = ex.MiddleWay(arrA, arrB);

            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }
    }

    [DataTestMethod]
    [DataRow(new int[] { 1, 2, 2, 1 }, 6)]
    [DataRow(new int[] { 1, 1, }, 2)]
    [DataRow(new int[] { 1, 2, 2, 1, 13 }, 6)]
    {
    public void Sum13Tests(int[] input, int expectedResult)
    {
        // Arrange
        LoopsAndArraysExercises ex = new LoopsAndArraysExercises();
        // Act
        int actualResult = ex.Sum13(input);
        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
}