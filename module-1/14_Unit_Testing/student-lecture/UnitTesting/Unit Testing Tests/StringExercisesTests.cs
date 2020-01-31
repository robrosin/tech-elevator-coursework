using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;

namespace Unit_Testing_Tests
{
    [TestClass]
    public class StringExercisesTests
    {
        [TestMethod]
        public void MakeAbba()
        {
            // Arrange 
            StringExercises exercise = new StringExercises();
            // Act
            string actualResult = exercise.MakeAbba("Hi", "Bye");

            // Assert
            Assert.AreEqual("HiByeByeHi", actualResult);
        }
        [TestMethod]
        public void MakeAbbaYoAdrian()
        {
            // Arrange 
            StringExercises exercise = new StringExercises();
            // Act
            string actualResult = exercise.MakeAbba("Yo", "Adrian");

            // Assert
            Assert.AreEqual("YoAdrianAdrianYo", actualResult);
        }
        [DataTestMethod]
        [DataRow("Hi", "Bye", "HiByeByeHi")]
        [DataRow("Yo", "Adrian", "YoAdrianAdrianYo")]
        [DataRow("What", "Up", "WhatUpUpWhat")]
        public void MakeAbbaTests(string stringA, string stringB, string expectedResult)
        {
            // Arrange
            StringExercises exercise = new StringExercises();

            //Act
            string actualResult = exercise.MakeAbba(stringA, stringB);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [DataTestMethod]
        [DataRow("Hello", "He", DisplayName = "More than two characters")]
        [DataRow("i", "i", DisplayName = "One character")]
        [DataRow("", "", DisplayName = "Empty string")]
        [DataRow("!=", "!=", DisplayName = "Exact;y two characters")]
        [DataRow(null, "", DisplayName = "Null string")]
        [DataRow(" ", " ", DisplayName = "Single space")]
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