using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class Category
    {
        const string EXCEPTION_TEXT = "out of range!";
        private List<Product> _products = new List<Product>();
        private int _category;
        private string _categoryName;

        public Category(int category, string categoryName)
        {
            _category = category;
            _categoryName = categoryName;
        }

        // 取得 product
        public Product GetProduct(int index)
        {
            if (IsIndexInDomain(index))
            {
                return _products[index];
            }
            throw new ArgumentException(EXCEPTION_TEXT);
        }

        // 取得最後一個 product
        public Product LastProduct
        {
            get
            {
                if (Count > 0)
                {
                    return _products[Count - 1];
                }
                return null;
            }
        }

        // 取得 name
        public string GetName(int index)
        { 
            if (IsIndexInDomain(index))
            {
                return _products[index].Name;
            }
            throw new ArgumentException(EXCEPTION_TEXT);
        }

        // 取得 description
        public string GetDescription(int index)
        {
            if (IsIndexInDomain(index))
            {
                return _products[index].Description;
            }
            throw new ArgumentException(EXCEPTION_TEXT);
        }

        // 取得 imagePath
        public string GetImagePath(int index)
        {
            if (IsIndexInDomain(index))
            {
                return _products[index].ImagePath;
            }
            throw new ArgumentException(EXCEPTION_TEXT);
        }

        // 取得 price
        public int GetPrice(int index)
        {
            if (IsIndexInDomain(index))
            {
                return _products[index].Price;
            }
            throw new ArgumentException(EXCEPTION_TEXT);
        }

        // 取得 stock
        public int GetStock(int index)
        {
            if (IsIndexInDomain(index))
            {
                return _products[index].StockAmount;
            }
            throw new ArgumentException(EXCEPTION_TEXT);
        }

        // 取得 product 數量
        public int Count
        {
            get
            {
                return _products.Count;
            }
        }

        // 加入 product
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // 刪除 product
        public void RemoveProductAt(int index)
        {
            if (IsIndexInDomain(index))
            {
                _products.RemoveAt(index);
            }
            else
            {
                throw new ArgumentException(EXCEPTION_TEXT);
            }
        }

        // 判斷 index 是否在 domain 內
        private bool IsIndexInDomain(int index)
        {
            return index >= 0 && index < Count;
        }
    }
}
