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
    public class PriceConverterTests
    {
        PriceConverter _priceConverter;
        PrivateObject _target;

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _priceConverter = new PriceConverter(9999999);
            _target = new PrivateObject(_priceConverter);
        }

        // 測試 constructor
        [TestMethod()]
        public void PriceConverterTest()
        {
            Assert.AreEqual(_target.GetField("_price"), 9999999);
        }

        // 測試 StandardPrice method
        [TestMethod()]
        public void StandardPriceTest()
        {
            Assert.AreEqual(_priceConverter.StandardPrice, "9,999,999");
        }

        // 測試 StandardDollar method
        [TestMethod()]
        public void StandardDollarTest()
        {
            Assert.AreEqual(_priceConverter.StandardDollar, "9,999,999元");
        }
    }
}