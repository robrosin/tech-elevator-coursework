using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class CigarPartyTests
    {
        [DataTestMethod]
        [DataRow(30, false, false)]
        [DataRow(50, false, true)]
        [DataRow(70, true, true)]

        public void CigarParty(int cigars, bool isWeekend, bool expected)
        {
            CigarParty ex = new CigarParty();

            bool actualResult = ex.HaveParty(cigars, isWeekend);

            Assert.AreEqual(expected, actualResult);
        }
    }
}