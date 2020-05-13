using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OrderApp
{
    public class ProductButton : Button
    {
        private int _tabCount;
        private int _buttonCount;

        // product button的constructor
        public ProductButton() : base()
        {
            // empty body
        }

        // 頁數的getter & setter
        public int TabCount
        {
            set
            {
                _tabCount = value;
            }
            get
            {
                return _tabCount;
            }
        }

        // button在頁中順序的getter & setter
        public int ButtonCount
        {
            set
            {
                _buttonCount = value;
            }
            get
            {
                return _buttonCount;
            }
        }
    }
}
