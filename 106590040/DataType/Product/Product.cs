using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class Product
    {
        private String _name;
        private int _stockAmount;
        private ProductInfo _info;

        // product的constructor
        public Product(String name, int stockAmount, ProductInfo info)
        {
            SetAll(name, stockAmount, info);
        }

        // 設定所有product的參數
        public void SetAll(String name, int stockAmount, ProductInfo info)
        {
            Name = name;
            StockAmount = stockAmount;
            Info = info;
        }

        // name的getter & setter
        public String Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }

        // 庫存數量的getter & setter
        public int StockAmount
        {
            set
            {
                if (value >= 0)
                {
                    _stockAmount = value;
                }
            }
            get
            {
                return _stockAmount;
            }
        }

        // info的getter & setter
        public ProductInfo Info
        {
            set
            {
                _info = value;
            }
            get
            {
                return _info;
            }
        }

        // description的getter
        public String Description
        {
            get
            {
                return _info.ProductDescription;
            }
        }

        // imagePath的getter
        public String ImagePath
        {
            get
            {
                return _info.ProductImagePath;
            }
        }

        // price的getter
        public int Price
        {
            get
            {
                return _info.ProductPrice;
            }
        }

        // 判斷product是否相等
        public bool IsEqual(Product product)
        {
            return Name == product.Name &&
                StockAmount == product.StockAmount &&
                Info.IsEqual(product.Info);
        }
    }
}
