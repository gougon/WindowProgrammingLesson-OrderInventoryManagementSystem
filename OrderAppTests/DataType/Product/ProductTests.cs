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
    public class ProductTests
    {
        Product _product;
        ProductInfo _productInfo;

        // 初始化
        [TestInitialize()]
        public void Initialize()
        {
            _productInfo = new ProductInfo("desc", "path", 10);
            _product = new Product("name", 100, _productInfo);
        }

        // 測試constructor
        [TestMethod()]
        public void ProductTest()
        {
            Assert.AreEqual(_product.Name, "name");
            Assert.AreEqual(_product.StockAmount, 100);
            Assert.AreEqual(_product.Info, _productInfo);
            Assert.AreEqual(_product.Description, "desc");
            Assert.AreEqual(_product.ImagePath, "path");
            Assert.AreEqual(_product.Price, 10);
        }
        
        // 測試SetAllTest mothod
        [TestMethod()]
        public void SetAllTest()
        {
            ProductInfo info = new ProductInfo("testDesc", "testPath", 100);
            _product.SetAll("testName", 10, info);
            Assert.AreEqual(_product.Name, "testName");
            Assert.AreEqual(_product.StockAmount, 10);
            Assert.AreEqual(_product.Info, info);
            Assert.AreEqual(_product.Description, "testDesc");
            Assert.AreEqual(_product.ImagePath, "testPath");
            Assert.AreEqual(_product.Price, 100);
            _product.SetAll("testName", -1, info);
            Assert.AreEqual(_product.StockAmount, 10);
        }

        // 測試 Name method
        [TestMethod()]
        public void NameTest()
        {
            Assert.AreEqual(_product.Name, "name");
            _product.Name = "modify name";
            Assert.AreEqual(_product.Name, "modify name");
        }

        // 測試 StockAmount method
        [TestMethod()]
        public void StockAmountTest()
        {
            Assert.AreEqual(_product.StockAmount, 100);
            _product.StockAmount = 10;
            Assert.AreEqual(_product.StockAmount, 10);
        }

        // 測試 Info method
        [TestMethod()]
        public void InfoTest()
        {
            ProductInfo info = new ProductInfo("desc", "path", 10);
            Assert.AreEqual(_product.Info.IsEqual(info), true);
            info = new ProductInfo("modify desc", "path", 10);
            Assert.AreEqual(_product.Info.IsEqual(info), false);
        }

        // 測試 Description method
        [TestMethod()]
        public void DescriptionTest()
        {
            Assert.AreEqual(_product.Description, "desc");
        }

        // 測試 ImagePath method
        [TestMethod()]
        public void ImagePathTest()
        {
            Assert.AreEqual(_product.ImagePath, "path");
        }

        // 測試 Price method
        [TestMethod()]
        public void PriceTest()
        {
            Assert.AreEqual(_product.Price, 10);
        }

        // 測試IsEqual method
        [TestMethod()]
        public void IsEqualTest()
        {
            Product product1 = new Product("name", 1, _productInfo);
            ProductInfo info = new ProductInfo("desc", "path", 10);
            Product product2 = new Product("name", 1, info);
            Assert.AreEqual(product1.IsEqual(product2), true);
            product2.Name = "modify name";
            Assert.AreEqual(product1.IsEqual(product2), false);
        }
    }
}