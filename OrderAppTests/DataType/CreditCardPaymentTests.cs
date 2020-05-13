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
    public class CreditCardPaymentTests
    {
        CreditCardPayment _creditCardPayment;

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _creditCardPayment = new CreditCardPayment();
        }

        // 測試 constructor
        [TestMethod()]
        public void CreditCardPaymentTest()
        {
            Assert.AreEqual(_creditCardPayment.FirstName, "");
            Assert.AreEqual(_creditCardPayment.LastName, "");
            for (int count = 0; count < 4; count++)
            {
                Assert.AreEqual(_creditCardPayment.CardNumber[count], "");
            }
            Assert.AreEqual(_creditCardPayment.Year, -1);
            Assert.AreEqual(_creditCardPayment.Month, -1);
            Assert.AreEqual(_creditCardPayment.Email, "");
            Assert.AreEqual(_creditCardPayment.Address, "");
        }

        // 測試FirstName
        [TestMethod()]
        public void FirstNameTest()
        {
            _creditCardPayment.FirstName = "firstName";
            Assert.AreEqual(_creditCardPayment.FirstName, "firstName");
        }

        // 測試LastName
        [TestMethod()]
        public void LastNameTest()
        {
            _creditCardPayment.LastName = "lastName";
            Assert.AreEqual(_creditCardPayment.LastName, "lastName");
        }

        // 測試Cardnumber
        [TestMethod()]
        public void CardNumberTest()
        {
            _creditCardPayment.CardNumber = new string[] { "0", "1", "2", "3" };
            for (int count = 0; count < 4; count++)
            {
                Assert.AreEqual(_creditCardPayment.CardNumber[count], count.ToString());
            }
        }

        // 測試Year
        [TestMethod()]
        public void YearTest()
        {
            _creditCardPayment.Year = 1;
            Assert.AreEqual(_creditCardPayment.Year, 1);
        }

        // 測試Month
        [TestMethod()]
        public void Test()
        {
            _creditCardPayment.Month = 10;
            Assert.AreEqual(_creditCardPayment.Month, 10);
        }

        // 測試Email
        [TestMethod()]
        public void EmailTest()
        {
            _creditCardPayment.Email = "abc@gmail.com";
            Assert.AreEqual(_creditCardPayment.Email, "abc@gmail.com");
        }

        // 測試Address
        [TestMethod()]
        public void AddressTest()
        {
            _creditCardPayment.Address = "123 456";
            Assert.AreEqual(_creditCardPayment.Address, "123 456");
        }

        // 測試 IsEqual method
        [TestMethod()]
        public void IsEqualTest()
        {
            CreditCardPayment creditCardPaymentCompare = new CreditCardPayment();
            Assert.AreEqual(_creditCardPayment.IsEqual(creditCardPaymentCompare), true);
            creditCardPaymentCompare.CardNumber = new string[] { "1", "2", "2", "2" };
            Assert.AreEqual(_creditCardPayment.IsEqual(creditCardPaymentCompare), false);
        }

        // 測試IsCardNumberEqual method
        [TestMethod()]
        public void IsCardNumberEqualTest()
        {
            CreditCardPayment creditCardPaymentCompare = new CreditCardPayment();
            _creditCardPayment.CardNumber = new string[] { "1", "2", "3", "4" };
            creditCardPaymentCompare.CardNumber = new string[] { "1", "2", "3", "4" };
            PrivateObject target = new PrivateObject(_creditCardPayment);
            Assert.AreEqual(target.Invoke("IsCardNumberEqual", new object[] { creditCardPaymentCompare.CardNumber }), true);
            creditCardPaymentCompare.CardNumber = new string[] { "1", "2", "3", "3" };
            Assert.AreEqual(target.Invoke("IsCardNumberEqual", new object[] { creditCardPaymentCompare.CardNumber }), false);
        }
    }
}