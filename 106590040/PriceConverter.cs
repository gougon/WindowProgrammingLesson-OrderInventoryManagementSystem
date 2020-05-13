using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class PriceConverter
    {
        const string STANDARD_PRICE_EXPRESSION = "#,0";
        const string DOLLAR = "元";
        private int _price;

        public PriceConverter(int price)
        {
            _price = price;
        }

        // 返回三位一個逗號
        public string StandardPrice
        {
            get
            {
                return _price.ToString(STANDARD_PRICE_EXPRESSION);
            }
        }

        // 返回加上"元"的價格
        public string StandardDollar
        {
            get
            {
                return _price.ToString(STANDARD_PRICE_EXPRESSION) + DOLLAR;
            }
        }
    }
}
