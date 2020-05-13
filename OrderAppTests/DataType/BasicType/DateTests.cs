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
    public class DateTests
    {
        Date _date;

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _date = new Date(103, 2, 3);
        }

        // 測試 constructor
        [TestMethod()]
        public void DateTest()
        {
            Assert.AreEqual(_date.Year, 103);
            Assert.AreEqual(_date.Month, 2);
            Assert.AreEqual(_date.Day, 3);
            _date = new Date();
            Assert.AreEqual(_date.Year, -1);
            Assert.AreEqual(_date.Month, -1);
            Assert.AreEqual(_date.Day, -1);
        }

        // 測試 Year
        [TestMethod()]
        public void YearTest()
        {
            _date.Year = 104;
            Assert.AreEqual(_date.Year, 104);
        }

        // 測試 Month
        [TestMethod()]
        public void MonthTest()
        {
            _date.Month = 1;
            Assert.AreEqual(_date.Month, 1);
        }

        // 測試 Day
        [TestMethod()]
        public void DayTest()
        {
            _date.Day = 28;
            Assert.AreEqual(_date.Day, 28);
        }
    }
}