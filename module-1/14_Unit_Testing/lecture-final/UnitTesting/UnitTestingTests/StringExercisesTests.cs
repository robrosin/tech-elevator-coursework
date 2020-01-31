using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;

namespace UnitTestingTests
{
    [TestClass]
    public class StringExercisesTests
    {
        [TestMethod]
        public void Run_makeabba_HiBye_should_return_HiByeByeHi()
        {
            // Arrange
            StringExercises ex = new StringExercises();

            // Act
            string actualResult = ex.MakeAbba("Hi", "Bye");

            // Assert
            Assert.AreEqual("HiByeByeHi", actualResult);
        }
        [TestMethod]
        public void Run_makeabba_YoAdrian_should_return_YoAdrianAdrianYo()
        {
            // Arrange
            StringExercises ex = new StringExercises();

            // Act
            string actualResult = ex.MakeAbba("Yo", "Adrian");

            // Assert
            Assert.AreEqual("YoAdrianAdrianYo", actualResult);
        }

        [DataTestMethod]
        [DataRow("Hi", "Bye", "HiByeByeHi", DisplayName = "Hi-Bye")]
        [DataRow("Yo", "Adrian", "YoAdrianAdrianYo", DisplayName = "Rocky")]
        [DataRow("What", "Up", "WhatUpUpWhat", DisplayName = "Bugs Bunny")]
        [DataRow("", "", "", DisplayName = "Test empty strings")]
        [DataRow(" ", "", "  ", DisplayName = "Test empty string and space")]
        [DataRow(null, null, "", DisplayName = "Test nulls")]
        public void MakeAbbaTests(string stringA, string stringB, string expectedResult)
        {
            // Arrange
            StringExercises ex = new StringExercises();

            //Act
            string actualResult = ex.MakeAbba(stringA, stringB);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow("Hello", "He", DisplayName = "More than two characters")]
        [DataRow("i", "i", DisplayName = "One character")]
        [DataRow("", "", DisplayName = "Empty string")]
        [DataRow(" ", " ", DisplayName = "Single space")]
        [DataRow("!=", "!=", DisplayName = "Exactly two characters")]
        [DataRow(null, "", DisplayName = "NULL string")]
        public void FirstTwoTests(string str, string expectedResult)
        {
            // Arrange
            StringExercises ex = new StringExercises();

            // Act
            string actualResult = ex.FirstTwo(str);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
