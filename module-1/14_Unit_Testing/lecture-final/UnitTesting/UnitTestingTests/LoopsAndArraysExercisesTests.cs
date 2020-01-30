using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestableClasses.Classes;

namespace UnitTestingTests
{
    [TestClass]
    public class LoopsAndArraysExercisesTests
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] {2, 5})]
        public void MiddleWayTests(int[] arrA, int[] arrB, int[] expectedResult)
        {
            // Arrange
            LoopsAndArrayExercises ex = new LoopsAndArrayExercises();


            // Act
            int[] actualResult = ex.MiddleWay(arrA, arrB);

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult);

        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 2, 1 }, 6)]
        [DataRow(new int[] { 1, 1 }, 2)]
        [DataRow(new int[] { 1, 2, 2, 1, 13 }, 6)]
        [DataRow(new int[] { 1, 2, 2, 1, 13, 7 }, 6)]
        [DataRow(new int[] { 1, 2, 2, 1, 13, 7, 8 }, 14)]
        [DataRow(new int[] { 1, 2, 2, 1, 13, 7, 8, 13, 4, 5 }, 19)]
        [DataRow(new int[] { 1, 2, 2, 1, 13, 13, 4, 5 }, 11)]
        [DataRow(new int[] { 1, 2, 2, 1, 13, 13 }, 6)]
        public void Sum13Tests(int[] input, int expectedResult)
        {
            // Arrange
            LoopsAndArrayExercises ex = new LoopsAndArrayExercises();

            // Act
            int actualResult = ex.Sum13(input);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }


    }
}
