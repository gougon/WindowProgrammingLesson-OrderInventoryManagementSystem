using System.Collections.Generic;

namespace _OrderApp
{
    public class OrderPresentationModel
    {
        public delegate void PresentationModelChangedEventHandler();
        public event PresentationModelChangedEventHandler _presentationModelChanged;
        const string TOTAL_PRICE_TEXT = "總金額:";
        const string UNIT_PRICE_TEXT = "單價:";
        const string STOCK_TEXT = "庫存數量:";
        const string PAGE_TEXT = "Page : ";
        const string FRACTION = " / ";
        const int THOUSAND = 1000;
        private OrderModel _model;
        private bool _isPlusProductButtonEnable = false;
        private bool _isNextButtonEnable = true;
        private bool _isBackButtonEnable = false;
        private bool _isOrderButtonEnable = false;
        private List<int> _productButtonCount = new List<int>();
        private List<int> _categoryProductCount = new List<int>();
        private int _page = 1;

        // presentation model的constructor
        public OrderPresentationModel(OrderModel model)
        {
            _model = model;
        }

        // 返回order product button的enable狀態
        public bool IsPlusProductButtonEnable
        {
            get
            {
                return _isPlusProductButtonEnable;
            }
        }

        // 返回next button的enable狀態
        public bool IsNextButtonEnable
        {
            get
            {
                return _isNextButtonEnable;
            }
        }

        // 返回back button的enable狀態
        public bool IsBackButtonEnable
        {
            get
            {
                return _isBackButtonEnable;
            }
        }

        // 返回order button的enable狀態
        public bool IsOrderButtonEnable
        {
            get
            {
                return _isOrderButtonEnable;
            }
        }

        // 返回某一種類的button數量
        public int GetProductButtonCount(int category)
        {
            return _productButtonCount[category];
        }

        // 返回目前 form 上的 category 數量
        public int CategoryCount
        {
            get
            {
                return _categoryProductCount.Count;
            }
        }

        // 返回頁數的text
        public string GetPageText(int category)
        {
            if (_page > GetCategoryPageCount(category))
            {
                _page--;
            }
            return PAGE_TEXT + _page.ToString() + FRACTION + GetCategoryPageCount(category).ToString();
        }

        // 返回price
        public string GetOrderPrice(string name)
        {
            int price = _model.GetProductPrice(name);
            return new PriceConverter(price).StandardPrice;
        }

        // 返回category
        public string GetOrderCategory(string name)
        {
            return _model.GetProductCategoryName(name);
        }

        // 返回總金額的text
        public string TotalPrice
        {
            get
            {
                return TOTAL_PRICE_TEXT + new PriceConverter(_model.TotalPrice).StandardDollar;
            }
        }

        // 返回單價金額的text
        public string GetProductPrice(int category, int index)
        {
            return UNIT_PRICE_TEXT + new PriceConverter(_model.GetProductPrice(category, index)).StandardDollar;
        }

        // 返回商品總價
        public string GetProductTotalPrice(string name, int amount)
        {
            Point categoryAndIndex = _model.GetCategoryAndIndexFromName(name);
            return new PriceConverter(_model.GetProductPrice(categoryAndIndex.Category, categoryAndIndex.Index) * amount).StandardDollar;
        }

        // 返回庫存數量的text
        public string GetProductStock(int category, int index)
        {
            return STOCK_TEXT + _model.GetProductStock(category, index);
        }

        // 對應按下product button要發生的事
        public void ClickProductButton(int category, int index)
        {
            _isPlusProductButtonEnable = IsProductEnough(category, index) && !_model.IsProductInOrder(category, index);
            _model.SetFocusProduct(category, index);
        }

        // 判斷產品的庫存是否>0
        private bool IsProductEnough(int category, int index)
        {
            return _model.GetProductStock(category, index) > 0;
        }

        // 對應按下order button要發生的事
        public void ClickPlusButton()
        {
            _model.OrderProduct();
            _isPlusProductButtonEnable = false;
            _isOrderButtonEnable = true;
            _model.SetFocusProduct(0, 0);
        }

        // 對應按下dgv內的刪除按鈕
        public void DeleteOrderProduct(int rowIndex)
        {
            _model.DeleteOrderProduct(rowIndex);
            _isOrderButtonEnable = (_model.OrderCount > 0);
            NotifyObserver();
        }

        // 對應按下next button要發生的事
        public void ClickNextButton(int category)
        {
            ++_page;
            PageChange(category);
        }

        // 對應按下back button要發生的事
        public void ClickBackButton(int category)
        {
            _productButtonCount[category] -= (OrderForm.EACH_TAB_COUNT + _productButtonCount[category] % OrderForm.EACH_TAB_COUNT);
            --_page;
            PageChange(category);
        }

        // 按下換頁button要發生的事
        private void PageChange(int category)
        {
            SetChangePageButtonsEnable(category);
            NotifyObserver();
        }

        // 判斷是否可以訂購(數量不超出上限)
        public bool CanOrder(int rowIndex, int amount)
        {
            return _model.GetProductStockFromOrder(rowIndex) >= amount;
        }

        // 對應focus從product button移開的事
        public void SetLeaveFocusFromProductButton(bool isFocused)
        {
            _isPlusProductButtonEnable = isFocused;
        }

        // 對應product tab control換頁的事件
        public void ChangeProductTabControlSelected(int category)
        {
            _productButtonCount[category] = 0;
            _page = 1;
            SetChangePageButtonsEnable(category);
            NotifyObserver();
        }

        // 創建一個productButton對應的事件
        public void CreateProductButton(int category)
        {
            ++_productButtonCount[category];
        }

        // 清除所有 product button 時發生的事件
        public void ClearProductButton()
        {
            _categoryProductCount.Clear();
            _productButtonCount.Clear();
        }

        // 加入一個 page 時發生的事件
        public void CreatePage()
        {
            int currentCategoryCount = _categoryProductCount.Count;
            int categoryCount = _model.CategoryCount;
            if (currentCategoryCount < categoryCount)
            {
                _categoryProductCount.Add(_model.GetProductCount(currentCategoryCount));
                _productButtonCount.Add(0);
            }
        }

        // 是否是此tab的最後一個product
        public bool IsFinalProduct(int category)
        {
            return _model.GetProductCount(category) == GetProductButtonCount(category);
        }

        // 計算該種類的總頁數
        private int GetCategoryPageCount(int category)
        {
            int totalPages = 0;
            if (_model.GetProductCount(category) % OrderForm.EACH_TAB_COUNT == 0)
            {
                totalPages = _categoryProductCount[category] / OrderForm.EACH_TAB_COUNT;
            }
            else
            {
                totalPages = _categoryProductCount[category] / OrderForm.EACH_TAB_COUNT + 1;
            }
            return totalPages;
        }

        // 對應產品改變的事件
        public void RefreshProducts()
        {
            for (int count = 0; count < _categoryProductCount.Count; count++)
            {
                RefreshProduct(count);
            }
        }

        // 改變單個 category 的產品
        private void RefreshProduct(int count)
        {
            _productButtonCount[count] = 0;
            _categoryProductCount[count] = _model.GetProductCount(count);
        }

        // 設定換頁button的enable
        public void SetChangePageButtonsEnable(int category)
        {
            _isNextButtonEnable = (_page != GetCategoryPageCount(category));
            _isBackButtonEnable = (_page != 1);
        }

        // 通知observer
        private void NotifyObserver()
        {
            if (_presentationModelChanged != null)
            {
                _presentationModelChanged();
            }
        }
    }
}
