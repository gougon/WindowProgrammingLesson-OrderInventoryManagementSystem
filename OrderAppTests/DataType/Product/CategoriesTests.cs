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
    public class CategoriesTests
    {
        Categories _categories;
        PrivateObject _target;

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _categories = new Categories();
            _target = new PrivateObject(_categories);
            _categories.AddCategory("test category");
            _target.Invoke("LoadCategoryProducts", new object[] { "../../../Product/testProducts.txt", 6 });
        }

        // 測試 Count method
        [TestMethod()]
        public void CountTest()
        {
            Assert.AreEqual(_categories.Count, 7);
        }

        // 測試 GetCategoryName method
        [TestMethod()]
        public void GetCategoryNameTest()
        {
            Assert.AreEqual(_categories.GetCategoryName(6), "test category");
        }

        // 測試 GetProduct method
        [TestMethod()]
        public void GetProductTest()
        {
            ProductInfo info = new ProductInfo("test description", "test path", 1);
            Product product = new Product("test name", 1, info);
            Assert.AreEqual(_categories.GetProduct(GetTestPoint()).IsEqual(product), true);
        }

        // 測試 GetName method
        [TestMethod()]
        public void GetNameTest()
        {
            Assert.AreEqual(_categories.GetName(GetTestPoint()), "test name");
        }

        // 測試 GetDescription method
        [TestMethod()]
        public void GetDescriptionTest()
        {
            Assert.AreEqual(_categories.GetDescription(GetTestPoint()), "test description");
        }

        // 測試 GetIntroduce method
        [TestMethod()]
        public void GetIntroduceTest()
        {
            Assert.AreEqual(_categories.GetIntroduce(GetTestPoint()), "test name" + Environment.NewLine + "test description");
        }

        // 測試 GetImagePath method
        [TestMethod()]
        public void GetImagePathTest()
        {
            Assert.AreEqual(_categories.GetImagePath(GetTestPoint()), "test path");
        }

        // 測試 GetPrice method
        [TestMethod()]
        public void GetPriceTest()
        {
            Assert.AreEqual(_categories.GetPrice(GetTestPoint()), 1);
        }

        // 測試 GetStock method
        [TestMethod()]
        public void GetStockTest()
        {
            Assert.AreEqual(_categories.GetStock(GetTestPoint()), 1);
        }

        // 測試 GetProductQuantityOfCategory
        [TestMethod()]
        public void GetProductQuantityOfCategoryTest()
        {
            Assert.AreEqual(_categories.GetProductQuantityOfCategory(6), 1);
        }

        // 測試 AddCategory method
        [TestMethod()]
        public void AddCategoryTest()
        {
            _categories.AddCategory("add category");
            Assert.AreEqual(_categories.Count, 8);
        }

        // 測試 AddProduct method
        [TestMethod()]
        public void AddProductTest()
        {
            ProductInfo info = new ProductInfo("add desc", "add path", 2);
            Product product = new Product("add name", 0, info);
            _categories.AddProduct(6, "add name", info);
            Assert.AreEqual(_categories.GetProductQuantityOfCategory(6), 2);
            Assert.AreEqual(_categories.GetProduct(new Point(6, GetLastProductIndex(6))).IsEqual(product), true);
        }

        // 測試 ModifyProduct with same category method
        [TestMethod()]
        public void ModifyEqualCategoryProductTest()
        {
            ProductInfo info = new ProductInfo("test description", "test path", 1);
            Product product = new Product("modify name", 1, info);
            _categories.ModifyProduct(GetTestPoint(), 6, "modify name", info);
            Assert.AreEqual(_categories.GetProduct(GetTestPoint()).IsEqual(product), true);
        }

        // 測試 ModifyProduct with different category method
        [TestMethod()]
        public void ModifyDifferentCategoryProductTest()
        {
            ProductInfo info = new ProductInfo("test description", "test path", 1);
            Product product = new Product("modify name", 1, info);
            _categories.ModifyProduct(GetTestPoint(), 0, "modify name", info);
            Assert.AreEqual(_categories.GetProductQuantityOfCategory(6), 0);
            Assert.AreEqual(_categories.GetProduct(new Point(0, GetLastProductIndex(0))).IsEqual(product), true);
        }

        // 測試 AddStock method
        [TestMethod()]
        public void AddStockTest()
        {
            _categories.AddStock(GetTestPoint(), 9);
            Assert.AreEqual(_categories.GetStock(GetTestPoint()), 10);
        }

        // 測試 GetCategoryAndIndexFromName method
        [TestMethod()]
        public void GetCategoryAndIndexFromNameTest()
        {
            Assert.AreEqual(_categories.GetCategoryAndIndexFromName("test name").IsEqual(new Point(6, 0)), true);
        }

        // 取得 (0, last) 的 point
        private Point GetTestPoint()
        {
            return new Point(6, 0);
        }

        // 取得 category 的 quantity
        private int GetLastProductIndex(int serialNumber)
        {
            return _categories.GetProductQuantityOfCategory(serialNumber) - 1;
        }
    }
}