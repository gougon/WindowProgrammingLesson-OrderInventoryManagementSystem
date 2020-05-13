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
    public class OrderModelTests
    {
        private OrderModel _model;
        private bool _modelChangedFlag;
        private bool _productChangedFlag;
        private PrivateObject _target;

        // mock model changed observer
        private void MockModelChanged()
        {
            _modelChangedFlag = true;
        }

        // mock product changed observer
        private void MockProductChanged()
        {
            _productChangedFlag = true;
        }

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _model = new OrderModel();
            _model._modelChanged += MockModelChanged;
            _model._productChanged += MockProductChanged;
            _modelChangedFlag = false;
            _productChangedFlag = false;
            _target = new PrivateObject(_model);
            ProductInfo info = new ProductInfo("desc", "path", 10);
            _model.AddCategory("category");
            _model.AddProduct(6, "name", info);
            _model.UpdateProductStock(6, 0, 15);
        }

        // 測試 Order method
        [TestMethod()]
        public void OrderTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Order order = _model.Order;
            Assert.AreEqual(order.GetProductName(0), "name");
        }

        // 測試 AddCategory method
        [TestMethod()]
        public void AddCategoryTest()
        {
            Assert.AreEqual(_model.GetProductCategoryName(6), "category");
        }

        // 測試 UpdateProductStock method
        [TestMethod()]
        public void UpdateProductStockTest()
        {
            _model.UpdateProductStock(6, 0, 5);
            Assert.AreEqual(_model.GetProductStock(6, 0), 20);
            Assert.AreEqual(_modelChangedFlag, true);
        }

        // 測試 OrderProduct method
        [TestMethod()]
        public void OrderProductTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_model.Order.GetProductName(0), "name");
            Assert.AreEqual(_modelChangedFlag, true);
        }

        // 測試 DeleteOrderProduct method
        [TestMethod()]
        public void DeleteOrderProductTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            _model.DeleteOrderProduct(0);
            Assert.AreEqual(_model.OrderCount, 0);
            Assert.AreEqual(_modelChangedFlag, true);
        }

        // 測試 IsProductInOrder method
        [TestMethod()]
        public void IsProductInOrderTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_model.IsProductInOrder(6, 0), true);
            Assert.AreEqual(_model.IsProductInOrder(5, 0), false);
        }

        // 測試 TradeOrder method
        [TestMethod()]
        public void TradeOrderTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            _model.TradeOrder();
            Assert.AreEqual(_model.GetProductStock(6, 0), 14);
        }

        // 測試 DeleteOrder method
        [TestMethod()]
        public void DeleteOrderTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            _model.SetFocusProduct(5, 0);
            _model.OrderProduct();
            _model.DeleteOrder();
            Assert.AreEqual(_model.OrderCount, 0);
            Assert.AreEqual(_modelChangedFlag, true);
        }

        // 測試 GetProductStockFromOrder method
        [TestMethod()]
        public void GetProductStockFromOrderTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_model.GetProductStockFromOrder(0), 15);
        }

        // 測試 UpdateOrderAmount method
        [TestMethod()]
        public void UpdateOrderAmountTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            _model.UpdateOrderAmount(0, 10);
            Assert.AreEqual(_model.Order.OrderAmount[0], 10);
            Assert.AreEqual(_modelChangedFlag, true);
        }

        // 測試 CategoryCount method
        [TestMethod()]
        public void CategoryCountTest()
        {
            Assert.AreEqual(_model.CategoryCount, 7);
        }

        // 測試 OrderCount method
        [TestMethod()]
        public void OrderCountTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_model.OrderCount, 1);
        }

        // 測試 IsOrderListEmpty mehtod
        [TestMethod()]
        public void IsOrderListEmptyTest()
        {
            Assert.AreEqual(_model.IsOrderListEmpty, true);
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_model.IsOrderListEmpty, false);
        }

        // 測試 TotalPrice method
        [TestMethod()]
        public void TotalPriceTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_model.TotalPrice, 10);
        }

        // 測試 GetCategoryAndIndexFromName method
        [TestMethod()]
        public void GetCategoryAndIndexFromNameTest()
        {
            Assert.AreEqual(_model.GetCategoryAndIndexFromName("name").IsEqual(new Point(6, 0)), true);
        }

        // 測試 GetNameFromOrderIndex method
        [TestMethod()]
        public void GetNameFromOrderIndexTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_model.GetNameFromOrderIndex(0), "name");
        }

        // 測試 SetFocusProduct method
        [TestMethod()]
        public void SetFocusProductTest()
        {
            _model.SetFocusProduct(6, 0);
            Assert.AreEqual(_model.GetProduct(6, 0).IsEqual((Product)_target.GetField("_focusProduct")), true);
            Assert.AreEqual(_modelChangedFlag, true);
        }

        // 測試 GetFocusProduct method
        [TestMethod()]
        public void GetFocusProductTest()
        {
            _model.SetFocusProduct(6, 0);
            Assert.AreEqual(_model.GetFocusProduct().IsEqual(_model.GetProduct(6, 0)), true);
        }

        // 測試 GetProduct method
        [TestMethod()]
        public void GetProductTest()
        {
            ProductInfo info = new ProductInfo("desc", "path", 10);
            Product product = new Product("name", 15, info);
            Assert.AreEqual(_model.GetProduct(6, 0).IsEqual(product), true);
        }

        // 測試 GetProductCount method
        [TestMethod()]
        public void GetProductCountTest()
        {
            Assert.AreEqual(_model.GetProductCount(6), 1);
        }

        // 測試 GetName method
        [TestMethod()]
        public void GetNameTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_model.GetName(6, 0), "name");
        }

        // 測試 GetProductStock method
        [TestMethod()]
        public void GetProductStockTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_model.GetProductStock(6, 0), 15);
        }

        // 測試 GetDescription method
        [TestMethod()]
        public void GetDescriptionWithPointTest()
        {
            Assert.AreEqual(_model.GetDescription(6, 0), "desc");
        }

        // 測試 GetDescription method
        [TestMethod()]
        public void GetDescriptionWithNameTest()
        {
            Assert.AreEqual(_model.GetDescription("name"), "desc");
        }

        // 測試 GetImagePath method
        [TestMethod()]
        public void GetImagePathTest()
        {
            Assert.AreEqual(_model.GetImagePath(6, 0), "path");
        }

        // 測試 GetProductPrice with point method
        [TestMethod()]
        public void GetProductPriceWithPointTest()
        {
            Assert.AreEqual(_model.GetProductPrice(6, 0), 10);
        }

        // 測試 GetProductPrice with name method
        [TestMethod()]
        public void GetProductPriceWithNameTest()
        {
            Assert.AreEqual(_model.GetProductPrice("name"), 10);
        }

        // 測試 GetProductCategoryName with serialNumber method
        [TestMethod()]
        public void GetProductCategoryNameWithSerialNumberTest()
        {
            Assert.AreEqual(_model.GetProductCategoryName(6), "category");
        }

        // 測試 GetProductCategoryName with name method
        [TestMethod()]
        public void GetProductCategoryNameWithPointTest()
        {
            Assert.AreEqual(_model.GetProductCategoryName("name"), "category");
        }

        // 測試 GetProductIntroduce method
        [TestMethod()]
        public void GetProductIntroduceTest()
        {
            Assert.AreEqual(_model.GetProductIntroduce(6, 0), "name" + Environment.NewLine + "desc");
        }

        // 測試 GetCategoryProductsName method
        [TestMethod()]
        public void GetCategoryProductsNameTest()
        {
            Assert.AreEqual(_model.GetCategoryProductsName(6), "name" + Environment.NewLine);
        }

        // 測試 ModifyProduct method
        [TestMethod()]
        public void ModifyProductTest()
        {
            ProductInfo info = new ProductInfo("desc", "path", 10);
            _model.ModifyProduct("name", 6, "modify name", info);
            Assert.AreEqual(_model.GetName(6, 0), "modify name");
            _model.ModifyProduct("modify name", 5, "modify name2", info);
            Assert.AreEqual(_model.GetName(5, _model.GetProductCount(5) - 1), "modify name2");
            Assert.AreEqual(_model.GetProductCount(6), 0);
            Assert.AreEqual(_productChangedFlag, true);
        }

        // 測試 AddProduct method
        [TestMethod()]
        public void AddProductTest()
        {
            ProductInfo info = new ProductInfo("desc", "path", 10);
            Product product = new Product("name", 15, info);
            Assert.AreEqual(_model.GetProduct(6, 0).IsEqual(product), true);
            Assert.AreEqual(_productChangedFlag, true);
        }
    }
}