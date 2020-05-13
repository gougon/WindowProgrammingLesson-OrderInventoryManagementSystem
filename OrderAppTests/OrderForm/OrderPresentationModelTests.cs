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
    public class OrderPresentationModelTests
    {
        private OrderPresentationModel _presentationModel;
        PrivateObject _target;
        private bool _isNotify = false;
        private OrderModel _model = new OrderModel();
        private ProductInfo _info = new ProductInfo("desc", "path", 9999999);

        // MockNotify
        private void Notify()
        {
            _isNotify = true;
        }

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _model.AddCategory("category");
            _model.AddProduct(6, "name", _info);
            _model.UpdateProductStock(6, 0, 15);
            _presentationModel = new OrderPresentationModel(_model);
            _presentationModel._presentationModelChanged += Notify;
            _target = new PrivateObject(_presentationModel);
            _isNotify = false;
            for (int count = 0; count < 7; count++)
            {
                _presentationModel.CreatePage();
            }
        }

        // 測試 IsPlusProductButtonEnable method
        [TestMethod()]
        public void IsPlusProductButtonEnableTest()
        {
            Assert.AreEqual(_presentationModel.IsPlusProductButtonEnable, false);
        }

        // 測試 IsNextButtonEnable method
        [TestMethod()]
        public void IsNextButtonEnableTest()
        {
            Assert.AreEqual(_presentationModel.IsNextButtonEnable, true);
        }

        // 測試 IsNextButtonEnable method
        [TestMethod()]
        public void IsBackButtonEnableTest()
        {
            Assert.AreEqual(_presentationModel.IsBackButtonEnable, false);
        }

        // 測試 IsOrderButtonEnable method
        [TestMethod()]
        public void IsOrderButtonEnableTest()
        {
            Assert.AreEqual(_presentationModel.IsOrderButtonEnable, false);
        }

        // 測試 GetProductButtonCount method
        [TestMethod()]
        public void GetProductButtonCountTest()
        {
            Assert.AreEqual(_presentationModel.GetProductButtonCount(6), 0);
        }

        // 測試 GetPageText method
        [TestMethod()]
        public void GetPageTextTest()
        {
            Assert.AreEqual(_presentationModel.GetPageText(6), "Page : 1 / 1");
            AddProducts(5);
            Assert.AreEqual(_presentationModel.GetPageText(6), "Page : 1 / 1");
            _model.AddProduct(6, "5", _info);
            Assert.AreEqual(_presentationModel.GetPageText(6), "Page : 1 / 2");
            _presentationModel.ClickNextButton(6);
            Assert.AreEqual(_presentationModel.GetPageText(6), "Page : 2 / 2");
            _model.ModifyProduct("5", 5, "5", _info);
            _presentationModel.RefreshProducts();
            Assert.AreEqual(_presentationModel.GetPageText(6), "Page : 1 / 1");
        }

        // 測試 GetOrderPrice method
        [TestMethod()]
        public void GetOrderPriceTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_presentationModel.GetOrderPrice("name"), "9,999,999");
        }

        // 測試 GetOrderCategory method
        [TestMethod()]
        public void GetOrderCategoryTest()
        {
            Assert.AreEqual(_presentationModel.GetOrderCategory("name"), "category");
        }

        // 測試 TotalPrice method
        [TestMethod()]
        public void TotalPriceTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            _model.UpdateOrderAmount(0, 10);
            Assert.AreEqual(_presentationModel.TotalPrice, "總金額:99,999,990元");
        }

        // 測試 GetProductPrice method
        [TestMethod()]
        public void GetProductPriceTest()
        {
            Assert.AreEqual(_presentationModel.GetProductPrice(6, 0), "單價:9,999,999元");
        }

        // 測試 GetProductTotalPrice method
        [TestMethod()]
        public void GetProductTotalPriceTest()
        {
            Assert.AreEqual(_presentationModel.GetProductTotalPrice("name", 10), "99,999,990元");
        }

        // 測試 GetProductStock method
        [TestMethod()]
        public void GetProductStockTest()
        {
            Assert.AreEqual(_presentationModel.GetProductStock(6, 0), "庫存數量:15");
        }

        // 測試 ClickProductButton method
        [TestMethod()]
        public void ClickProductButtonTest()
        {
            _presentationModel.ClickProductButton(6, 0);
            Assert.AreEqual(_model.GetFocusProduct().IsEqual(_model.GetProduct(6, 0)), true);
            Assert.AreEqual(_presentationModel.IsPlusProductButtonEnable, true);
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            _model.UpdateOrderAmount(0, 15);
            _model.TradeOrder();
            _presentationModel.ClickProductButton(6, 0);
            Assert.AreEqual(_presentationModel.IsPlusProductButtonEnable, false);
        }

        // 測試 IsProductEnough method
        [TestMethod()]
        public void IsProductEnoughTest()
        {
            Assert.AreEqual(_target.Invoke("IsProductEnough", new object[] { 6, 0 }), true);
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            _model.UpdateOrderAmount(0, 15);
            _model.TradeOrder();
            Assert.AreEqual(_target.Invoke("IsProductEnough", new object[] { 6, 0 }), false);
        }

        // 測試 ClickPlusButton method
        [TestMethod()]
        public void ClickPlusButtonTest()
        {
            _model.SetFocusProduct(6, 0);
            _presentationModel.ClickPlusButton();
            Assert.AreEqual(_model.OrderCount, 1);
            Assert.AreEqual(_presentationModel.IsPlusProductButtonEnable, false);
            Assert.AreEqual(_presentationModel.IsOrderButtonEnable, true);
            Assert.AreEqual(_model.GetFocusProduct().IsEqual(_model.GetProduct(0, 0)), true);
        }

        // 測試 DeleteOrderProduct method
        [TestMethod()]
        public void DeleteOrderProductTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            _presentationModel.DeleteOrderProduct(0);
            Assert.AreEqual(_model.OrderCount, 0);
            Assert.AreEqual(_presentationModel.IsOrderButtonEnable, false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 ClickNextButton method
        [TestMethod()]
        public void ClickNextButtonTest()
        {
            AddProducts(6);
            _presentationModel.ClickNextButton(6);
            Assert.AreEqual(_presentationModel.GetPageText(6), "Page : 2 / 2");
        }

        // 測試 ClickBackButton method
        [TestMethod()]
        public void ClickBackButtonTest()
        {
            AddProducts(6);
            _presentationModel.ClickNextButton(6);
            _presentationModel.ClickBackButton(6);
            Assert.AreEqual(_presentationModel.GetPageText(6), "Page : 1 / 2");
        }

        // 測試 CanOrder method
        [TestMethod()]
        public void CanOrderTest()
        {
            _model.SetFocusProduct(6, 0);
            _model.OrderProduct();
            Assert.AreEqual(_presentationModel.CanOrder(0, 1), true);
            Assert.AreEqual(_presentationModel.CanOrder(0, 15), true);
            Assert.AreEqual(_presentationModel.CanOrder(0, 16), false);
        }

        // 測試 SetLeaveFocusFromProductButton method
        [TestMethod()]
        public void SetLeaveFocusFromProductButtonTest()
        {
            _presentationModel.SetLeaveFocusFromProductButton(true);
            Assert.AreEqual(_presentationModel.IsPlusProductButtonEnable, true);
            _presentationModel.SetLeaveFocusFromProductButton(false);
            Assert.AreEqual(_presentationModel.IsPlusProductButtonEnable, false);
        }

        // 測試 ChangeProductTabControlSelectedIndex method
        [TestMethod()]
        public void ChangeProductTabControlSelectedTest()
        {
            _presentationModel.ChangeProductTabControlSelected(0);
            Assert.AreEqual(_presentationModel.GetProductButtonCount(0), 0);
            Assert.AreEqual(_presentationModel.IsNextButtonEnable, true);
            Assert.AreEqual(_presentationModel.IsBackButtonEnable, false);
        }

        // 測試 CreateProductButton method
        [TestMethod()]
        public void CreateProductButtonTest()
        {
            _presentationModel.CreateProductButton(6);
            Assert.AreEqual(_presentationModel.GetProductButtonCount(6), 1);
        }

        // 測試 IsFinalProduct method
        [TestMethod()]
        public void IsFinalProductTest()
        {
            _presentationModel.CreateProductButton(6);
            Assert.AreEqual(_presentationModel.IsFinalProduct(6), true);
            AddProducts(6);
            Assert.AreEqual(_presentationModel.IsFinalProduct(6), false);
        }

        // 測試 GetCategoryPageCount method
        [TestMethod()]
        public void GetCategoryPageCountTest()
        {
            Assert.AreEqual(_target.Invoke("GetCategoryPageCount", new object[] { 0 }), 2);
            Assert.AreEqual(_target.Invoke("GetCategoryPageCount", new object[] { 6 }), 1);
        }

        // 測試 RefreshProducts method
        [TestMethod()]
        public void RefreshProductsTest()
        {
            _model.AddProduct(6, "name2", _info);
            _presentationModel.RefreshProducts();
            Assert.AreEqual(_presentationModel.GetProductButtonCount(6), 0);
            Assert.AreEqual(((List<int>)_target.GetField("_categoryProductCount"))[6], 2);
        }

        // 測試 SetChangePageButtonsEnable method
        [TestMethod()]
        public void SetChangePageButtonsEnableTest()
        {
            AddProducts(6);
            _presentationModel.SetChangePageButtonsEnable(6);
            Assert.AreEqual(_presentationModel.IsNextButtonEnable, true);
            Assert.AreEqual(_presentationModel.IsBackButtonEnable, false);
            _presentationModel.ClickNextButton(6);
            Assert.AreEqual(_presentationModel.IsNextButtonEnable, false);
            Assert.AreEqual(_presentationModel.IsBackButtonEnable, true);
        }

        // 測試 ClearProductButton method
        [TestMethod()]
        public void ClearProductButtonTest()
        {
            Assert.AreEqual(_presentationModel.CategoryCount, 7);
            _presentationModel.ClearProductButton();
            Assert.AreEqual(_presentationModel.CategoryCount, 0);
        }

        // 測試 CategoryCount method
        [TestMethod()]
        public void CategoryCountTest()
        {
            Assert.AreEqual(_presentationModel.CategoryCount, 7);
        }

        // 增加一頁
        private void AddProducts(int quantity)
        {
            for (int count = 0; count < quantity; count++)
            {
                _model.AddProduct(6, count.ToString(), _info);
                _presentationModel.RefreshProducts();
                _presentationModel.CreateProductButton(6);
            }
        }
    }
}