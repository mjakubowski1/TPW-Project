using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPW_Step_0_Test
{
    using TPW_Step_0;

    [TestClass]
    public class AddTest
    {
        [TestMethod]
        public void Test1()
        {
            Calculator obj = new Calculator();
            Assert.AreEqual(4, obj.add(2, 2));
            Assert.AreEqual(0, obj.add(-2, 2));
            Assert.AreEqual(-1, obj.add(-5, 4));
            Assert.AreEqual(-11, obj.add(-9, -2));
        }
    }

    [TestClass]
    public class SubTest
    {
        [TestMethod]
        public void Test1()
        {
            Calculator obj = new Calculator();
            Assert.AreEqual(8, obj.sub(12, 4));
            Assert.AreEqual(0, obj.sub(2, 2));
            Assert.AreEqual(-15, obj.sub(-10, 5));
            Assert.AreEqual(2, obj.sub(-5, -7));
        }
    }

    [TestClass]
    public class MulTest
    {
        [TestMethod]
        public void Test1()
        {
            Calculator obj = new Calculator();
            Assert.AreEqual(32, obj.mul(8, 4));
            Assert.AreEqual(0, obj.mul(2, 0));
            Assert.AreEqual(-20, obj.mul(-5, 4));
            Assert.AreEqual(80, obj.mul(-10, -8));
        }
    }

    [TestClass]
    public class DivTest
    {
        [TestMethod]
        public void Test1()
        {
            Calculator obj = new Calculator();
            Assert.AreEqual(5, obj.div(70, 14));
            Assert.AreEqual(0, obj.div(0, 9));
            Assert.AreEqual(-4, obj.div(-12, 3));
            Assert.AreEqual(7, obj.div(-28, -4));
        }
    }

}