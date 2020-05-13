using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _OrderApp
{
    public class MenuPresentationModel
    {
        public delegate void PresentationModelChangedEventHandler();
        public event PresentationModelChangedEventHandler _presentationModelChanged;
        private bool _isOrderButtonEnable = true;
        private bool _isInventoryButtonEnable = true;
        private bool _isProductManageButtonEnable = true;

        // 傳回order button的enable狀態
        public bool IsOrderButtonEnable
        {
            get
            {
                return _isOrderButtonEnable;
            }
        }

        // 傳回inventory button的enable狀態
        public bool IsInventoryButtonEnable
        {
            get
            {
                return _isInventoryButtonEnable;
            }
        }

        // 傳回product manage button的enable狀態
        public bool IsProductManageButtonEnable
        {
            get
            {
                return _isProductManageButtonEnable;
            }
        }

        // 對應按下order button的動作
        public void ClickOrderButton()
        {
            _isOrderButtonEnable = false;
            NotifyObserver();
        }

        // 對應關閉order form的動作
        public void CloseOrderForm()
        {
            _isOrderButtonEnable = true;
            NotifyObserver();
        }

        // 對應按下Inventory button的動作
        public void ClickInventoryButton()
        {
            _isInventoryButtonEnable = false;
            NotifyObserver();
        }

        // 對應關閉inventory form的動作
        public void CloseInventoryForm()
        {
            _isInventoryButtonEnable = true;
            NotifyObserver();
        }

        // 對應按下Product Manage button的動作
        public void ClickProductManageButton()
        {
            _isProductManageButtonEnable = false;
            NotifyObserver();
        }

        // 對應關閉Product Manage form的動作
        public void CloseProductManageForm()
        {
            _isProductManageButtonEnable = true;
            NotifyObserver();
        }

        // 依照順序取得ui的margin_top
        public int GetMarginTop(int order)
        {
            int interval = MenuForm.UI_INTERVAL * (order + 1);
            int uiHeight = MenuForm.MENU_BUTTON_HEIGHT * order;
            return interval + uiHeight;
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
