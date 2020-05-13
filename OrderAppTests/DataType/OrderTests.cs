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
    public class OrderTests
    {
        Order _order;
        PrivateObject _target;
        Product _product;

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _order = new Order(new CreditCardPayment());
            _target = new PrivateObject(_order);
            ProductInfo info = new ProductInfo("desc", "path", 1);
            _product = new Product("name", 1, info);
        }

        // 測試 Count method
        [TestMethod()]
        public void CountTest()
        {
            Assert.AreEqual(_order.Count, 0);
            _order.OrderProduct(_product);
            Assert.AreEqual(_order.Count, 1);
        }

        // 測試 IsOrderListEmpty method
        [TestMethod()]
        public void IsOrderListEmptyTest()
        {
            Assert.AreEqual(_order.IsOrderListEmpty, true);
            _order.OrderProduct(_product);
            Assert.AreEqual(_order.IsOrderListEmpty, false);
        }

        // 測試 GetProductName method
        [TestMethod()]
        public void GetProductNameTest()
        {
            Assert.AreEqual(_order.GetProductName(0), "");
            _order.OrderProduct(_product);
            Assert.AreEqual(_order.GetProductName(0), "name");
            Assert.AreEqual(_order.GetProductName(1), "");
            Assert.AreEqual(_order.GetProductName(-1), "");
        }

        // 測試 CreditCardPayment method
        [TestMethod()]
        public void CreditCardPaymentTest()
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment();
            creditCardPayment.FirstName = "first";
            _order.CreditCardPayment = creditCardPayment;
            Assert.AreEqual(_order.CreditCardPayment.FirstName, "first");
            Assert.AreEqual(_order.CreditCardPayment.IsEqual(creditCardPayment), true);
        }

        // 測試 OrderList method
        [TestMethod()]
        public void OrderListTest()
        {
            _order.OrderProduct(_product);
            Assert.AreEqual(_order.OrderAmount[0], 1);
            Assert.AreEqual(_order.OrderList[0].IsEqual(_product), true);
        }

        // 測試 OrderAmount method
        [TestMethod()]
        public void OrderAmountTest()
        {
            _order.OrderProduct(_product);
            Assert.AreEqual(_order.OrderAmount[0], 1);
            _order.DeleteProduct(0);
            Assert.AreEqual(_order.OrderAmount.Count, 0);
        }

        // 測試FirstName method
        [TestMethod()]
        public void FirstNameTest()
        {
            Assert.AreEqual(_order.FirstName, "");
            _order.FirstName = "first name";
            Assert.AreEqual(_order.FirstName, "first name");
        }

        // 測試LastName method
        [TestMethod()]
        public void LastNameTest()
        {
            Assert.AreEqual(_order.LastName, "");
            _order.LastName = "last name";
            Assert.AreEqual(_order.LastName, "last name");
        }

        // 測試 CardNumber method
        [TestMethod()]
        public void CardNumberTest()
        {
            _order.CardNumber = new string[] { "0", "1", "2", "3" };
            for (int count = 0; count < 4; count++)
            {
                Assert.AreEqual(_order.CardNumber[count], count.ToString());
            }
        }

        // 測試 Year method
        [TestMethod()]
        public void YearTest()
        {
            Assert.AreEqual(_order.Year, -1);
            _order.Year = 105;
            Assert.AreEqual(_order.Year, 105);
        }

        // 測試 Month method
        [TestMethod()]
        public void MonthTest()
        {
            Assert.AreEqual(_order.Month, -1);
            _order.Month = 10;
            Assert.AreEqual(_order.Month, 10);
        }

        // 測試 Email method
        [TestMethod()]
        public void EmailTest()
        {
            Assert.AreEqual(_order.Email, "");
            _order.Email = "abc@gmail.com";
            Assert.AreEqual(_order.Email, "abc@gmail.com");
        }

        // 測試 Address method
        [TestMethod()]
        public void AddressTest()
        {
            Assert.AreEqual(_order.Address, "");
            _order.Address = "123 456";
            Assert.AreEqual(_order.Address, "123 456");
        }

        // 測試 OrderProduct method
        [TestMethod()]
        public void OrderProductTest()
        {
            _order.OrderProduct(_product);
            Assert.AreEqual(_order.GetProductName(0), "name");
        }

        // 測試 DeleteProductTest method
        [TestMethod()]
        public void DeleteProductTest()
        {
            _order.OrderProduct(_product);
            _order.OrderProduct(_product);
            Assert.AreEqual(_order.Count, 2);
            _order.DeleteProduct(0);
            Assert.AreEqual(_order.Count, 1);
        }

        // 測試 DeleteAllTest method
        [TestMethod()]
        public void DeleteAllTest()
        {
            _order.OrderProduct(_product);
            _order.OrderProduct(_product);
            _order.DeleteAll();
            Assert.AreEqual(_order.IsOrderListEmpty, true);
        }

        // 測試 UpdateProductAmount method
        [TestMethod()]
        public void UpdateProductAmountTest()
        {
            _order.OrderProduct(_product);
            _order.UpdateProductAmount(0, 10);
            Assert.AreEqual(_order.OrderAmount[0], 10);
        }

        // 測試 Trade
        [TestMethod()]
        public void TradeTest()
        {
            _order.OrderProduct(_product);
            _order.Trade();
            Assert.AreEqual(_product.StockAmount, 0);
        }

        // 測試訂單數量與商品數量不一致的 Trade
        [TestMethod()]
        public void TradePartOfProductStock()
        {
            _product.StockAmount = 15;
            _order.OrderProduct(_product);
            _order.UpdateProductAmount(0, 10);
            _order.Trade();
            Assert.AreEqual(_product.StockAmount, 5);
        }

        // 測試 ModifyProduct method
        [TestMethod()]
        public void ModifyProductTest()
        {
            ProductInfo info = new ProductInfo("modify desc", "modify path", 100);
            Product product = new Product("modify name", 10, info);
            _order.OrderProduct(_product);
            _order.ModifyProduct("name", product);
            Assert.AreEqual(_order.GetProductName(0), "modify name");
        }

        // 測試 FindProductIndex method
        [TestMethod()]
        public void FindProductIndexTest()
        {
            _order.OrderProduct(_product);
            ProductInfo info = new ProductInfo("desc", "path", 1);
            Product product = new Product("name", 1, info);
            Assert.AreEqual(_order.FindProductIndex(product), -1);
            Assert.AreEqual(_order.FindProductIndex(_product), 0);
        }

        // 測試 TotalPrice method
        [TestMethod()]
        public void TotalPriceTest()
        {
            _product.StockAmount = 15;
            _order.OrderProduct(_product);
            Assert.AreEqual(_order.TotalPrice, 1);
            _order.UpdateProductAmount(0, 10);
            Assert.AreEqual(_order.TotalPrice, 10);
            ProductInfo info = new ProductInfo("add desc", "add path", 100);
            Product product = new Product("add name", 10, info);
            _order.OrderProduct(product);
            _order.UpdateProductAmount(1, 5);
            Assert.AreEqual(_order.TotalPrice, 510);
        }

        // 測試 CalculateTotalPrice method
        [TestMethod()]
        public void CalculateTotalPriceTest()
        {
            _product.StockAmount = 15;
            _order.OrderProduct(_product);
            Assert.AreEqual(_target.Invoke("CalculateTotalPrice"), 1);
            ProductInfo info = new ProductInfo("add desc", "add path", 100);
            Product product = new Product("add name", 10, info);
            _order.OrderProduct(product);
            _order.UpdateProductAmount(1, 5);
            Assert.AreEqual(_target.Invoke("CalculateTotalPrice"), 501);
        }
    }
}