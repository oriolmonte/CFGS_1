using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tire.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [DataRow(0, 0)]
        [DataRow(1, 6.28)]
        [DataRow(783.02 , 4919.86)]

        [TestMethod()]

        public void TireTest(double radi, double expected)
        {
            double actual = Program.TireLength(radi);
            Assert.AreEqual(expected, actual);
        }
    }
}