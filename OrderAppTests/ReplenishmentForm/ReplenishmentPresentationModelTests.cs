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
    public class ReplenishmentPresentationModelTests
    {
        ReplenishmentPresentationModel _presentationModel;
        OrderModel _model;
        PrivateObject _target;
        ProductInfo _info;

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _info = new ProductInfo("desc", "path", 9999999);
            _model = new OrderModel();
            _model.AddCategory("category");
            _model.AddProduct(6, "name", _info);
            _model.UpdateProductStock(6, 0, 15);
            _presentationModel = new ReplenishmentPresentationModel(_model);
            _target = new PrivateObject(_presentationModel);
        }

        // 測試 IsNumber method
        [TestMethod()]
        public void IsNumberTest()
        {
            Assert.AreEqual(_presentationModel.IsNumber('0'), true);
            Assert.AreEqual(_presentationModel.IsNumber('9'), true);
            Assert.AreEqual(_presentationModel.IsNumber('a'), false);
            Assert.AreEqual(_presentationModel.IsNumber('@'), false);
            Assert.AreEqual(_presentationModel.IsNumber('\b'), true);
        }

        // 測試 GetNameText method
        [TestMethod()]
        public void GetNameTextTest()
        {
            Assert.AreEqual(_presentationModel.GetNameText(6, 0), "商品名稱:name");
        }

        // 測試 GetPriceText method
        [TestMethod()]
        public void GetPriceTextTest()
        {
            Assert.AreEqual(_presentationModel.GetPriceText(6, 0), "商品單價:9999999");
        }

        // 測試 GetStockAmountText method
        [TestMethod()]
        public void GetStockAmountTextTest()
        {
            Assert.AreEqual(_presentationModel.GetStockAmountText(6, 0), "庫存數量:15");
        }
    }
}