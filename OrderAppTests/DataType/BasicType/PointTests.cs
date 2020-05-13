using Microsoft.VisualStudio.TestTools.UnitTesting;
using _OrderApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp.Tests
{
    [TestClass()]
    public class PointTests
    {
        Point _point;

        // 初始化
        [TestInitialize()]
        public void Initialize()
        {
            _point = new Point(1, 10);
        }

        // 測試constructor一定要是正數
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PointPositiveTest()
        {
            _point = new Point(-1, 10);
        }

        // 測試constructor without parameter
        [TestMethod()]
        public void PointTest()
        {
            _point = new Point();
            Assert.AreEqual(_point.Category, 0);
            Assert.AreEqual(_point.Index, 0);
        }

        // 測試Category property
        [TestMethod()]
        public void CategoryTest()
        {
            Assert.AreEqual(_point.Category, 1);
        }

        // 測試Index property
        [TestMethod()]
        public void IndexTest()
        {
            Assert.AreEqual(_point.Index, 10);
        }

        // 測試IsEqual method
        [TestMethod()]
        public void IsEqualTest()
        {
            Point comparePoint = new Point(1, 10);
            Assert.AreEqual(_point.IsEqual(comparePoint), true);
            comparePoint.Category = 2;
            Assert.AreEqual(_point.IsEqual(comparePoint), false);
        }
    }
}