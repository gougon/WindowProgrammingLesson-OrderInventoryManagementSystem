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
    public class CreditCardPaymentPresentationModelTests
    {
        CreditCardPaymentPresentationModel _presentationModel;
        OrderModel _model;
        PrivateObject _target;
        bool _isNotify;

        // MockNotify
        private void Notify()
        {
            _isNotify = true;
        }

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _presentationModel = new CreditCardPaymentPresentationModel(new OrderModel());
            _target = new PrivateObject(_presentationModel);
            _model = (OrderModel)_target.GetField("_model");
            _presentationModel._presentationModelChanged += Notify;
            _isNotify = false;
        }

        // 測試IsConfirmButtonEnable method
        [TestMethod()]
        public void IsConfirmButtonEnable()
        {
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmFirstName("first");
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmLastName("last");
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmFirstCardNumber("1234");
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmSecondCardNumber("2234");
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmThirdCardNumber("3234");
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmFourthCardNumber("4234");
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmMonth(10);
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmYear(2018);
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmLastNumber("567");
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmEmail("a@gmail.com");
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, false);
            _presentationModel.ConfirmAddress("address");
            Assert.AreEqual(_presentationModel.IsConfirmButtonEnable, true);
        }

        // 測試 ConfirmFirstName method
        [TestMethod()]
        public void ConfirmFirstNameTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmFirstName("first"), null);
            Assert.AreEqual(_presentationModel.ConfirmFirstName(""), "名稱必須輸入字串");
        }

        // 測試 ConfirmLastName method
        [TestMethod()]
        public void ConfirmLastNameTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmLastName("last"), null);
            Assert.AreEqual(_presentationModel.ConfirmLastName(""), "名稱必須輸入字串");
        }

        // 測試 ConfirmName method
        [TestMethod()]
        public void ConfirmNameTest()
        {
            bool isNameAvailable = false;
            object[] args = new object[] { isNameAvailable, 1 };
            Assert.AreEqual(_target.Invoke("ConfirmName", args), null);
            Assert.AreEqual(args[0], true);
            args[1] = 0;
            Assert.AreEqual(_target.Invoke("ConfirmName", args), "名稱必須輸入字串");
            Assert.AreEqual(args[0], false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 GetNameErrorText method
        [TestMethod()]
        public void GetNameErrorTextTest()
        {
            Assert.AreEqual(_target.Invoke("GetNameErrorText", new object[] { true }), null);
            Assert.AreEqual(_target.Invoke("GetNameErrorText", new object[] { false }), "名稱必須輸入字串");
        }

        // 測試 ConfirmFirstCardNumber method
        [TestMethod()]
        public void ConfirmFirstCardNumberTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmFirstCardNumber("1234"), null);
            Assert.AreEqual(_presentationModel.ConfirmFirstCardNumber("123"), "卡號必須是4位數字");
        }

        // 測試 ConfirmSecondCardNumber method
        [TestMethod()]
        public void ConfirmSecondCardNumberTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmSecondCardNumber("1234"), null);
            Assert.AreEqual(_presentationModel.ConfirmSecondCardNumber("123"), "卡號必須是4位數字");
        }

        // 測試 ConfirmThirdCardNumber method
        [TestMethod()]
        public void ConfirmThirdCardNumberTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmThirdCardNumber("1234"), null);
            Assert.AreEqual(_presentationModel.ConfirmThirdCardNumber("123"), "卡號必須是4位數字");
        }

        // 測試 ConfirmFourthCardNumber method
        [TestMethod()]
        public void ConfirmFourthCardNumberTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmFourthCardNumber("1234"), null);
            Assert.AreEqual(_presentationModel.ConfirmFourthCardNumber("123"), "卡號必須是4位數字");
        }

        // 測試 ConfirmCardNumber method
        [TestMethod()]
        public void ConfirmCardNumberTest()
        {
            bool isCardNumberAvailable = false;
            object[] args = new object[] { isCardNumberAvailable, 4 };
            Assert.AreEqual(_target.Invoke("ConfirmCardNumber", args), null);
            Assert.AreEqual(args[0], true);
            args[1] = 0;
            Assert.AreEqual(_target.Invoke("ConfirmCardNumber", args), "卡號必須是4位數字");
            Assert.AreEqual(args[0], false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 GetCardNumberErrorText method
        [TestMethod()]
        public void GetCardNumberErrorTextTest()
        {
            Assert.AreEqual(_target.Invoke("GetCardNumberErrorText", new object[] { true }), null);
            Assert.AreEqual(_target.Invoke("GetCardNumberErrorText", new object[] { false }), "卡號必須是4位數字");
        }

        // 測試 ConfirmMonth method
        [TestMethod()]
        public void ConfirmMonthTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmMonth(0), null);
            Assert.AreEqual(_presentationModel.ConfirmMonth(-1), "必須選擇日期");
        }

        // 測試 ConfirmYear method
        [TestMethod()]
        public void ConfirmYearTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmYear(0), null);
            Assert.AreEqual(_presentationModel.ConfirmYear(-1), "必須選擇日期");
        }

        // 測試 ConfirmDate method
        [TestMethod()]
        public void ConfirmDateTest()
        {
            bool isDateAvailable = false;
            object[] args = new object[] { isDateAvailable, 0 };
            Assert.AreEqual(_target.Invoke("ConfirmDate", args), null);
            Assert.AreEqual(args[0], true);
            args[1] = -1;
            Assert.AreEqual(_target.Invoke("ConfirmDate", args), "必須選擇日期");
            Assert.AreEqual(args[0], false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 GetDateErrorText method
        [TestMethod()]
        public void GetDateErrorTextTest()
        {
            Assert.AreEqual(_target.Invoke("GetDateErrorText", new object[] { true }), null);
            Assert.AreEqual(_target.Invoke("GetDateErrorText", new object[] { false }), "必須選擇日期");
        }

        // 測試 ConfirmLastNumber method
        [TestMethod()]
        public void ConfirmLastNumberTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmLastNumber("123"), null);
            Assert.AreEqual(_target.GetField("_isLastNumberAvailable"), true);
            Assert.AreEqual(_presentationModel.ConfirmLastNumber("12"), "末三碼必須是三位數字");
            Assert.AreEqual(_target.GetField("_isLastNumberAvailable"), false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 ConfirmEmail method
        [TestMethod()]
        public void ConfirmEmailTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmEmail("2@gmail.com"), null);
            Assert.AreEqual(_target.GetField("_isEmailAvailable"), true);
            Assert.AreEqual(_presentationModel.ConfirmEmail("12"), "Email格式錯誤");
            Assert.AreEqual(_target.GetField("_isEmailAvailable"), false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 ConfirmAddress method
        [TestMethod()]
        public void ConfirmAddressTest()
        {
            Assert.AreEqual(_presentationModel.ConfirmAddress("a"), null);
            Assert.AreEqual(_target.GetField("_isAddressAvailable"), true);
            Assert.AreEqual(_presentationModel.ConfirmAddress(""), "必須輸入地址");
            Assert.AreEqual(_target.GetField("_isAddressAvailable"), false);
            Assert.AreEqual(_isNotify, true);
        }

        // 測試 IsCharacterString method
        [TestMethod()]
        public void IsCharacterStringTest()
        {
            Assert.AreEqual(_presentationModel.IsCharacterString('a'), true);
            Assert.AreEqual(_presentationModel.IsCharacterString('\b'), true);
            Assert.AreEqual(_presentationModel.IsCharacterString('測'), true);
            Assert.AreEqual(_presentationModel.IsCharacterString('1'), false);
        }

        // 測試 IsFourPlaceNumber method
        [TestMethod()]
        public void IsFourPlaceNumberTest()
        {
            Assert.AreEqual(_presentationModel.IsFourPlaceNumber(0, '1'), true);
            Assert.AreEqual(_presentationModel.IsFourPlaceNumber(3, '1'), true);
            Assert.AreEqual(_presentationModel.IsFourPlaceNumber(3, '\b'), true);
            Assert.AreEqual(_presentationModel.IsFourPlaceNumber(4, '\b'), true);
            Assert.AreEqual(_presentationModel.IsFourPlaceNumber(4, '1'), false);
            Assert.AreEqual(_presentationModel.IsFourPlaceNumber(0, 'a'), false);
        }

        // 測試 IsThreePlaceNumber method
        [TestMethod()]
        public void IsThreePlaceNumberTest()
        {
            Assert.AreEqual(_presentationModel.IsThreePlaceNumber(0, '1'), true);
            Assert.AreEqual(_presentationModel.IsThreePlaceNumber(2, '1'), true);
            Assert.AreEqual(_presentationModel.IsThreePlaceNumber(2, '\b'), true);
            Assert.AreEqual(_presentationModel.IsThreePlaceNumber(3, '\b'), true);
            Assert.AreEqual(_presentationModel.IsThreePlaceNumber(3, '1'), false);
            Assert.AreEqual(_presentationModel.IsThreePlaceNumber(0, 'a'), false);
        }

        // 測試 IsEmail method
        [TestMethod()]
        public void IsEmailTest()
        {
            Assert.AreEqual(_target.Invoke("IsEmail", new object[] { "2" }), false);
            Assert.AreEqual(_target.Invoke("IsEmail", new object[] { "2@gmail.com" }), true);
        }
    }
}