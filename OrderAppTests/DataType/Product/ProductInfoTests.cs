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
    public class ProductInfoTests
    {
        // 測試constructor
        [TestMethod()]
        public void ProductInfoTest()
        {
            ProductInfo info = new ProductInfo();
            Assert.AreEqual(info.ProductDescription, "");
            Assert.AreEqual(info.ProductImagePath, "");
            Assert.AreEqual(info.ProductPrice, 0);
        }

        // 測試constructor with parameter
        [TestMethod()]
        public void ProductInfoWithParameterTest()
        {
            ProductInfo info = new ProductInfo("desc", "path", 10);
            Assert.AreEqual(info.ProductDescription, "desc");
            Assert.AreEqual(info.ProductImagePath, "path");
            Assert.AreEqual(info.ProductPrice, 10);
        }

        // 測試SetAllTest method
        [TestMethod()]
        public void SetAllTest()
        {
            ProductInfo info = new ProductInfo();
            info.SetAll("desc", "path", 10);
            Assert.AreEqual(info.ProductDescription, "desc");
            Assert.AreEqual(info.ProductImagePath, "path");
            Assert.AreEqual(info.ProductPrice, 10);
            info.ProductPrice = -1;
            Assert.AreEqual(info.ProductPrice, 10);
        }

        // 測試IsEqual method
        [TestMethod()]
        public void IsEqualTest()
        {
            ProductInfo info1 = new ProductInfo();
            ProductInfo info2 = new ProductInfo();
            Assert.AreEqual(info1.IsEqual(info2), true);
            info2.ProductDescription = "MODIFY DESC";
            Assert.AreEqual(info1.IsEqual(info2), false);
        }
    }
}