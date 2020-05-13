using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace _OrderApp
{
    public class InventoryPresentationModel
    {
        const string STANDARD_PRICE_EXPRESSION = "#,0";
        private OrderModel _model;

        // constructor
        public InventoryPresentationModel(OrderModel model)
        {
            _model = model;
        }

        // 取得價錢的標準表示法
        public string GetStandardPrice(int price)
        {
            return price.ToString(STANDARD_PRICE_EXPRESSION);
        }
    }
}
