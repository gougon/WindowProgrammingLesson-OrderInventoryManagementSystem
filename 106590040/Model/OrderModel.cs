using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _OrderApp
{
    public class OrderModel
    {
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModifyProductEventHandler();
        public event ModifyProductEventHandler _productChanged;
        private Order _order = new Order(new CreditCardPayment());
        private Categories _categories;
        private Product _focusProduct;

        public OrderModel()
        {
            _categories = new Categories();
        }

        // order的getter
        public Order Order
        {
            get
            {
                return _order;
            }
        }

        // 增加category
        public void AddCategory(string name)
        {
            _categories.AddCategory(name);
            NotifyProductObserver();
        }

        // 修改product的庫存
        public void UpdateProductStock(int category, int index, int amount)
        {
            _categories.AddStock(new Point(category, index), amount);
            NotifyObserver();
        }

        // 將focusProduct加入訂單
        public void OrderProduct()
        {
            _order.OrderProduct(_focusProduct);
            NotifyObserver();
        }

        // 將商品從order中移除
        public void DeleteOrderProduct(int order)
        {
            _order.DeleteProduct(order);
            NotifyObserver();
        }

        // 判斷商品是否已存在order內
        public bool IsProductInOrder(int category, int index)
        {
            return _order.FindProductIndex(_categories.GetProduct(new Point(category, index))) != -1;
        }

        // 購買訂單內容
        public void TradeOrder()
        {
            _order.Trade();
        }

        // 將order清空
        public void DeleteOrder()
        {
            _order.DeleteAll();
            NotifyObserver();
        }

        // 從order中返回庫存量
        public int GetProductStockFromOrder(int rowIndex)
        {
            return _order.OrderList[rowIndex].StockAmount;
        }

        // 更新order產品的數量
        public void UpdateOrderAmount(int rowIndex, int amount)
        {
            _order.UpdateProductAmount(rowIndex, amount);
            NotifyObserver();
        }

        // 取得category的數量
        public int CategoryCount
        {
            get
            {
                return _categories.Count;
            }
        }

        // 取得orderList的數量
        public int OrderCount
        {
            get
            {
                return _order.Count;
            }
        }

        // 判斷orderList是否為空
        public bool IsOrderListEmpty
        {
            get
            {
                return _order.IsOrderListEmpty;
            }
        }

        // totalPrice的getter
        public int TotalPrice
        {
            get
            {
                return _order.TotalPrice;
            }
        }

        // 透過name取得category and index
        public Point GetCategoryAndIndexFromName(string name)
        {
            return _categories.GetCategoryAndIndexFromName(name);
        }

        // 透過rowIndex取得name
        public string GetNameFromOrderIndex(int index)
        {
            return _order.GetProductName(index);
        }

        // 設定fucusProduct
        public void SetFocusProduct(int category, int index)
        {
            _focusProduct = _categories.GetProduct(new Point(category, index));
            NotifyObserver();
        }

        // 取得focusProduct
        public Product GetFocusProduct()
        {
            return _focusProduct;
        }

        // 取得product
        public Product GetProduct(int category, int index)
        {
            return _categories.GetProduct(new Point(category, index));
        }

        // 取得某一個種類的產品數量
        public int GetProductCount(int category)
        {
            return _categories.GetProductQuantityOfCategory(category);
        }

        // 取得name
        public string GetName(int category, int index)
        {
            return _categories.GetName(new Point(category, index));
        }

        // 取得數量
        public int GetProductStock(int category, int index)
        {
            return _categories.GetStock(new Point(category, index));
        }

        // 取得description
        public string GetDescription(int category, int index)
        {
            return _categories.GetDescription(new Point(category, index));
        }

        // 取得description
        public string GetDescription(string name)
        {
            return _categories.GetDescription(GetCategoryAndIndexFromName(name));
        }

        // 取得imagePath
        public string GetImagePath(int category, int index)
        {
            return _categories.GetImagePath(new Point(category, index));
        }

        // 取得price(category and index)
        public int GetProductPrice(int category, int index)
        {
            return _categories.GetPrice(new Point(category, index));
        }

        // 取得price(name)
        public int GetProductPrice(string name)
        {
            return _categories.GetPrice(GetCategoryAndIndexFromName(name));
        }

        // 取得category(name)
        public string GetProductCategoryName(int category)
        {
            return _categories.GetCategoryName(category);
        }

        // 取得category(name)
        public string GetProductCategoryName(string name)
        {
            return _categories.GetCategoryName(GetCategoryAndIndexFromName(name).Category);
        }

        // 取得產品介紹
        public string GetProductIntroduce(int category, int index)
        {
            return _categories.GetIntroduce(new Point(category, index));
        }

        // 取得 category 全部 product 的 name
        public string GetCategoryProductsName(int category)
        {
            string names = "";
            if (category != -1)
            {
                for (int index = 0; index < GetProductCount(category); index++)
                {
                    names += (GetName(category, index) + Environment.NewLine);
                }
            }
            return names;
        }

        // 修改商品資訊
        public void ModifyProduct(string originName, int modifyCategory, string modifyName, ProductInfo info)
        {
            Point categoryAndIndex = GetCategoryAndIndexFromName(originName);
            Product product = _categories.ModifyProduct(categoryAndIndex, modifyCategory, modifyName, info);
            _order.ModifyProduct(originName, product);
            NotifyProductObserver();
        }

        // 新增產品
        public void AddProduct(int category, string name, ProductInfo info)
        {
            _categories.AddProduct(category, name, info);
            NotifyProductObserver();
        }

        // 通知observer
        private void NotifyObserver()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        // 通知modify product observer
        private void NotifyProductObserver()
        {
            if (_productChanged != null)
            {
                _productChanged();
            }
        }
    }
}
