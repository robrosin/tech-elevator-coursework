using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]

    public class WordCountTests
    {
        [TestMethod]
        public void TestBaba()
        {
            // Arrange

            WordCount wc = new WordCount();
            Dictionary<string, int> expectedResult = new Dictionary<string, int>()

            {
            {"ba", 2 },
            {"black", 1 },
            {"sheep", 1 },
        };

            // Act

            Dictionary<string, int> actualResult = wc.GetCount(new string[] { "ba", "ba", "black", "sheep" });

            // Assert

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
