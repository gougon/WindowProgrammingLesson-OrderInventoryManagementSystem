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
    public class InventoryPresentationModelTests
    {
        InventoryPresentationModel _presentationModel;

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _presentationModel = new InventoryPresentationModel(new OrderModel());
        }

        // 測試 GetStandardPrice method
        [TestMethod()]
        public void GetStandardPriceTest()
        {
            Assert.AreEqual(_presentationModel.GetStandardPrice(9999999), "9,999,999");
        }
    }
}