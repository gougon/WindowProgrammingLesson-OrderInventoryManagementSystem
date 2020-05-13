using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _OrderApp
{
    public class ReplenishmentPresentationModel
    {
        const string NAME_TEXT = "商品名稱:";
        const string PRICE_TEXT = "商品單價:";
        const string STOCK_AMOUNT_TEXT = "庫存數量:";
        private OrderModel _model;

        public ReplenishmentPresentationModel(OrderModel model)
        {
            _model = model;
        }

        // 判斷是否為數字
        public bool IsNumber(char key)
        {
            return Char.IsDigit(key) || key == CreditCardPaymentPresentationModel.DELETE;
        }

        // 取得name的text
        public string GetNameText(int category, int index)
        {
            return NAME_TEXT + _model.GetName(category, index);
        }

        // 取得price的text
        public string GetPriceText(int category, int index)
        {
            return PRICE_TEXT + _model.GetProductPrice(category, index);
        }

        // 取得stockAmount的text
        public string GetStockAmountText(int category, int index)
        {
            return STOCK_AMOUNT_TEXT + _model.GetProductStock(category, index);
        }
    }
}
