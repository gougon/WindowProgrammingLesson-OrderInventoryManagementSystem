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
    public class MenuPresentationModelTests
    {
        MenuPresentationModel _presentationModel;
        bool _isNotify = false;

        // MockNotify
        private void Notify()
        {
            _isNotify = true;
        }

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _presentationModel = new MenuPresentationModel();
            _presentationModel._presentationModelChanged += Notify;
            _isNotify = false;
        }

        // 測試 IsOrderButtonEnable method
        [TestMethod()]
        public void IsOrderButtonEnableTest()
        {
            Assert.AreEqual(_presentationModel.IsOrderButtonEnable, true);
        }

        // 測試 IsInventoryButtonEnable method
        [TestMethod()]
        public void IsInventoryButtonEnableTest()
        {
            Assert.AreEqual(_presentationModel.IsInventoryButtonEnable, true);
        }

        // 測試 IsInventoryButtonEnable method
        [TestMethod()]
        public void IsProductManageButtonEnableTest()
        {
            Assert.AreEqual(_presentationModel.IsProductManageButtonEnable, true);
        }

        // 測試 ClickOrderButton method
        [TestMethod()]
        public void ClickOrderButtonTest()
        {
            _presentationModel.ClickOrderButton();
            Assert.AreEqual(_presentationModel.IsOrderButtonEnable, false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 CloseOrderForm method
        [TestMethod()]
        public void CloseOrderFormTest()
        {
            _presentationModel.CloseOrderForm();
            Assert.AreEqual(_presentationModel.IsOrderButtonEnable, true);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 ClickInventoryButton method
        [TestMethod()]
        public void ClickInventoryButtonTest()
        {
            _presentationModel.ClickInventoryButton();
            Assert.AreEqual(_presentationModel.IsInventoryButtonEnable, false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 CloseInventoryForm method
        [TestMethod()]
        public void CloseInventoryFormTest()
        {
            _presentationModel.CloseInventoryForm();
            Assert.AreEqual(_presentationModel.IsInventoryButtonEnable, true);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 ClickProductManageButton method
        [TestMethod()]
        public void ClickProductManageButtonTest()
        {
            _presentationModel.ClickProductManageButton();
            Assert.AreEqual(_presentationModel.IsProductManageButtonEnable, false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 CloseProductManageForm method
        [TestMethod()]
        public void CloseProductManageFormTest()
        {
            _presentationModel.CloseProductManageForm();
            Assert.AreEqual(_presentationModel.IsProductManageButtonEnable, true);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 GetMarginTop method
        [TestMethod()]
        public void GetMarginTopTest()
        {
            Assert.AreEqual(_presentationModel.GetMarginTop(1), 104);
        }
    }
}