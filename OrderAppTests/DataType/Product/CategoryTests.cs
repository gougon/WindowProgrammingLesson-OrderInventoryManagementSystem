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
    public class CategoryTests
    {
        Category _category;
        PrivateObject _target;
        Product _product;

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _category = new Category(0, "test");
            _target = new PrivateObject(_category);
            ProductInfo info = new ProductInfo("desc", "path", 10);
            _product = new Product("name", 100, info);
        }

        // 測試 constructor
        [TestMethod()]
        public void CategoryTest()
        {
            Assert.AreEqual(_target.GetField("_category"), 0);
            Assert.AreEqual(_target.GetField("_categoryName"), "test");
        }

        // 測試 GetProduct method
        [TestMethod()]
        public void GetProductTest()
        {
            _category.AddProduct(_product);
            Assert.AreEqual(_category.GetProduct(0), _product);
        }

        // 測試 GetProduct out of range method
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void GetProductOutOfRangeTest()
        {
            _category.GetProduct(0);
        }

        // 測試 LastProduct method
        [TestMethod()]
        public void LastProductTest()
        {
            Assert.AreEqual(_category.LastProduct, null);
            _category.AddProduct(_product);
            Assert.AreEqual(_category.LastProduct, _product);
            ProductInfo info = new ProductInfo("desc2", "path2", 10);
            Product product = new Product("name2", 10, info);
            _category.AddProduct(product);
            Assert.AreEqual(_category.LastProduct, product);
        }

        // 測試 GetName method
        [TestMethod()]
        public void GetNameTest()
        {
            _category.AddProduct(_product);
            Assert.AreEqual(_category.GetName(0), "name");
        }

        // 測試 GetName out of range method
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void GetNameOutOfRangeTest()
        {
            _category.GetName(0);
        }

        // 測試 GetDescription method
        [TestMethod()]
        public void GetDescriptionTest()
        {
            _category.AddProduct(_product);
            Assert.AreEqual(_category.GetDescription(0), "desc");
        }

        // 測試 GetDescription out of range method
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void GetDescriptionOutOfRangeTest()
        {
            _category.GetDescription(0);
        }

        // 測試 GetImagePath method
        [TestMethod()]
        public void GetImagePathTest()
        {
            _category.AddProduct(_product);
            Assert.AreEqual(_category.GetImagePath(0), "path");
        }

        // 測試 GetImagePath out of range method
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void GetImagePathOutOfRangeTest()
        {
            _category.GetImagePath(0);
        }

        // 測試 GetPrice method
        [TestMethod()]
        public void GetPriceTest()
        {
            _category.AddProduct(_product);
            Assert.AreEqual(_category.GetPrice(0), 10);
        }

        // 測試 GetPrice out of range method
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void GetPriceOutOfRangeTest()
        {
            _category.GetPrice(0);
        }

        // 測試 GetStock
        [TestMethod()]
        public void GetStockTest()
        {
            _category.AddProduct(_product);
            Assert.AreEqual(_category.GetStock(0), 100);
        }

        // 測試 GetStock out of range method
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void GetStockOutOfRangeTest()
        {
            _category.GetStock(0);
        }

        // 測試 Count method
        [TestMethod()]
        public void CountTest()
        {
            Assert.AreEqual(_category.Count, 0);
            _category.AddProduct(_product);
            Assert.AreEqual(_category.Count, 1);
        }

        // 測試 AddProduct method
        [TestMethod()]
        public void AddProductTest()
        {
            Assert.AreEqual(_category.Count, 0);
            _category.AddProduct(_product);
            Assert.AreEqual(_category.Count, 1);
        }

        // 測試 RemoveProductAt method
        [TestMethod()]
        public void RemoveProductAtTest()
        {
            _category.AddProduct(_product);
            _category.RemoveProductAt(0);
            Assert.AreEqual(_category.Count, 0);
        }

        // 測試 RemoveProductAt out of range method
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void RemoveProductAtOutOfRangeTest()
        {
            _category.RemoveProductAt(0);
        }

        // 測試 IsIndexInDomain method
        [TestMethod()]
        public void IsIndexInDomainTest()
        {
            Assert.AreEqual(_target.Invoke("IsIndexInDomain", new object[] { 0 }), false);
            _category.AddProduct(_product);
            Assert.AreEqual(_target.Invoke("IsIndexInDomain", new object[] { 0 }), true);
            Assert.AreEqual(_target.Invoke("IsIndexInDomain", new object[] { 1 }), false);
            Assert.AreEqual(_target.Invoke("IsIndexInDomain", new object[] { -1 }), false);
        }
    }
}