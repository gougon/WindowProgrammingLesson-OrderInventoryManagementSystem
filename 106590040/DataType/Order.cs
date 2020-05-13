using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class Order
    {
        private List<Product> _orderList = new List<Product>();
        private List<int> _orderAmount = new List<int>();
        private CreditCardPayment _creditCardPayment = new CreditCardPayment();

        // order的constructor
        public Order(CreditCardPayment creditCardPayment)
        {
            _creditCardPayment = creditCardPayment;
        }

        // 返回order list大小
        public int Count
        {
            get
            {
                return _orderList.Count();
            }
        }

        // 判斷orderList是否為空
        public bool IsOrderListEmpty
        {
            get
            {
                return _orderList.Count <= 0;
            }
        }

        // 取得index順位的name
        public string GetProductName(int index)
        {
            if (index >= 0 && index < Count)
            {
                return _orderList[index].Name;
            }
            return "";
        }

        // creditCardPayment的setter & getter
        public CreditCardPayment CreditCardPayment
        {
            set
            {
                _creditCardPayment = value;
            }
            get
            {
                return _creditCardPayment;
            }
        }

        // order list的getter
        public List<Product> OrderList
        {
            get
            {
                return _orderList;
            }
        }

        // order amount的getter
        public List<int> OrderAmount
        {
            get
            {
                return _orderAmount;
            }
        }

        // surname的setter & getter
        public string FirstName
        {
            set
            {
                _creditCardPayment.FirstName = value;
            }
            get
            {
                return _creditCardPayment.FirstName;
            }
        }

        // forename的setter & getter
        public string LastName
        {
            set
            {
                _creditCardPayment.LastName = value;
            }
            get
            {
                return _creditCardPayment.LastName;
            }
        }

        // card number的setter & getter
        public string[] CardNumber
        {
            set
            {
                _creditCardPayment.CardNumber = value;
            }
            get
            {
                return _creditCardPayment.CardNumber;
            }
        }

        // available year的setter & getter
        public int Year
        {
            set
            {
                _creditCardPayment.Year = value;
            }
            get
            {
                return _creditCardPayment.Year;
            }
        }

        // available month的setter & getter
        public int Month
        {
            set
            {
                _creditCardPayment.Month = value;
            }
            get
            {
                return _creditCardPayment.Month;
            }
        }

        // email的setter & getter
        public string Email
        {
            set
            {
                _creditCardPayment.Email = value;
            }
            get
            {
                return _creditCardPayment.Email;
            }
        }

        // address的setter & getter
        public string Address
        {
            set
            {
                _creditCardPayment.Address = value;
            }
            get
            {
                return _creditCardPayment.Address;
            }
        }

        // 加入訂單
        public void OrderProduct(Product product)
        {
            _orderList.Add(product);
            _orderAmount.Add(1);
        }

        // 刪除訂單
        public void DeleteProduct(int order)
        {
            _orderList.RemoveAt(order);
            _orderAmount.RemoveAt(order);
        }

        // 刪除所有訂單
        public void DeleteAll()
        {
            _orderList.Clear();
            _orderAmount.Clear();
        }

        // 修改訂單數量
        public void UpdateProductAmount(int order, int amount)
        {
            _orderAmount[order] = amount;
        }

        // 購買訂單內容
        public void Trade()
        {
            for (int row = 0; row < _orderList.Count; ++row)
            {
                _orderList[row].StockAmount -= _orderAmount[row];
            }
        }

        // 修改product內容
        public void ModifyProduct(string originName, Product modifyProduct)
        {
            int index = _orderList.FindIndex(product => product.Name == originName);
            if (index != -1)
            {
                _orderList[index] = modifyProduct;
            }
        }

        // 返回product在order list內的index
        public int FindProductIndex(Product product)
        {
            return _orderList.FindIndex(productInOrder => productInOrder == product);
        }

        // totalPrice的getter
        public int TotalPrice
        {
            get
            {
                return CalculateTotalPrice();
            }
        }

        // 計算總價
        private int CalculateTotalPrice()
        {
            int totalPrice = 0;
            for (int order = 0; order < _orderList.Count; ++order)
            {
                totalPrice += (_orderList[order].Price * _orderAmount[order]);
            }
            return totalPrice;
        }
    }
}
