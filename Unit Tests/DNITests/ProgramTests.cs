using Microsoft.VisualStudio.TestTools.UnitTesting;
using DNI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [DataRow(92201604, 'D')]
        [DataRow(88966607, 'P')]
        [DataRow(97421060, 'Y')]
        [DataRow(44903443, 'Z')]
        [DataRow(46253662, 'H')]
        [DataRow(78958911, 'A')]
        [DataRow(21264095, 'C')]
        [DataRow(91578363, 'E')]
        [DataRow(45602171, 'W')]
        [DataRow(18630511, 'M')]
        [DataRow(34784652, 'G')]
        [DataRow(87012970, 'Z')]
        [DataRow(08637759, 'V')]
        [DataRow(15968037, 'B')]
        [DataRow(79639317, 'T')]
        [DataRow(55753945, 'J')]
        [DataRow(59870045, 'X')]
        [DataRow(23895754, 'L')]
        [DataRow(69123448, 'F')]
        [DataRow(04368885, 'N')]
        [DataRow(56352844, 'S')]
        [DataRow(37895851, 'Q')]
        [DataRow(63500915, 'P')]

        [TestMethod()]
        public void LletraDNITest(int dni, char expected)
        {
            char actual = Program.LletraDNI(dni);
            Assert.AreEqual(expected, actual);
        }
    }
}