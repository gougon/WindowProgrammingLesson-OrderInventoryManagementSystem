using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _OrderApp
{
    public class ProductInfo
    {
        private String _productDescription;
        private String _productImagePath;
        private int _productPrice;

        // productInfo的constructor
        public ProductInfo()
        {
            SetAll("", "", 0);
        }

        // productInfo的constructor
        public ProductInfo(String productDescription, String productImagePath, int productPrice)
        {
            SetAll(productDescription, productImagePath, productPrice);
        }

        // 設定所有productInfo的參數
        public void SetAll(String productDescription, String productImagePath, int productPrice)
        {
            ProductDescription = productDescription;
            ProductImagePath = productImagePath;
            ProductPrice = productPrice;
        }

        // productDesc的getter & setter
        public String ProductDescription
        {
            set
            {
                _productDescription = value;
            }
            get
            {
                return _productDescription;
            }
        }

        // productImage的getter & setter
        public String ProductImagePath
        {
            set
            {
                _productImagePath = value;
            }
            get
            {
                return _productImagePath;
            }
        }

        // productPrice的getter & setter
        public int ProductPrice
        {
            set
            {
                if (value >= 0)
                {
                    _productPrice = value;
                }
            }
            get
            {
                return _productPrice;
            }
        }

        // 判斷info是否相同
        public bool IsEqual(ProductInfo info)
        {
            return ProductDescription == info.ProductDescription &&
                ProductImagePath == info.ProductImagePath &&
                ProductPrice == info.ProductPrice;
        }
    }
}
