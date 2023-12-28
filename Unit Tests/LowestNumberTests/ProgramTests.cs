using Microsoft.VisualStudio.TestTools.UnitTesting;
using LowestNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.Immutable;

namespace LowestNumber.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [DataRow(new int[] { 4, 2, 3, 5, 6 }, 2)]
        [DataRow(new int[] { 0, 1, 1, 1, 1 }, 0)]
        [DataRow(new int[] { 5, 4, 3, 2, 1 }, 1)]
        [DataRow(new int[] { 5, 5, 5, 5, 5 }, 5)]
        [DataRow(new int[] { 6, 7, 8, 9, 10 }, 6)]

        [TestMethod()]

        public void SmallestIntTest(int[] ints, int expected)
        {
            int actual = Program.SmallestInt(ints);
            Assert.AreEqual(expected, actual);
        }
    }
}