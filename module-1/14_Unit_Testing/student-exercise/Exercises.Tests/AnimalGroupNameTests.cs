using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNameTests
    {
        [DataTestMethod]
        [DataRow("giraffe", "Tower")]
        [DataRow("", "unknown")]
        [DataRow("walrus", "unknown")]
        [DataRow("Rhino", "Crash")]
        [DataRow("rhino", "Crash")]
        [DataRow("elephants", "unknown")]

        public void AnimalGroupName(string animalName, string expected)
        {
            AnimalGroupName ex = new AnimalGroupName();

            string actualResult = ex.GetHerd(animalName);

            Assert.AreEqual(expected, actualResult);
        }
    }
}