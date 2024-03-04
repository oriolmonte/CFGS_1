using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcMark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcMark.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void CalcMarkTest()
        {
            //Arrange
            int num = 5;
            string expected = "C";
            //Act
            string actual = Program.CalcMark(num);
            //Assert
            Assert.AreEqual(expected,actual);
        }
    }
}