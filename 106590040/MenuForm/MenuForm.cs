using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OrderApp
{
    public enum MenuList
    {
        Order = 0, 
        Inventory = 1, 
        ProductManage = 2
    }

    public partial class MenuForm : Form
    {
        public const int MENU_BUTTON_WIDTH = 650;
        public const int MENU_BUTTON_HEIGHT = 80;
        public const int MENU_TYPE_SIZE = 20;
        public const int EXIT_BUTTON_WIDTH = 160;
        public const int EXIT_BUTTON_HEIGHT = 50;
        public const int EXIT_TYPE_SIZE = 16;
        public const int UI_INTERVAL = 12;
        const string ORDER_SYSTEM_TITLE = "Order System";
        const string INVENTORY_SYSTEM_TITLE = "Inventory System";
        const string PRODUCT_MANAGE_SYSTEM_TITLE = "Product Manage System";
        const string TYPE = "Arial";
        private MenuPresentationModel _presentationModel;
        private OrderForm _orderForm;
        private InventoryForm _inventoryForm;
        private ProductManageForm _productManageForm;
        private OrderModel _orderModel;
        private List<Button> _menuButtons = new List<Button>();
        private Button _exitButton;

        public MenuForm(MenuPresentationModel presentationModel)
        {
            InitializeComponent();
            _orderModel = new OrderModel();
            _presentationModel = presentationModel;
            CreateUserInterface();
            GiveEvents();
        }

        // 視窗關閉事件
        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            _presentationModel._presentationModelChanged -= RefreshControls;
        }

        // Order Button的click事件
        private void ClickOrderButton(object sender, EventArgs e)
        {
            _presentationModel.ClickOrderButton();
            _orderForm = new OrderForm(new OrderPresentationModel(_orderModel), _orderModel);
            _orderForm.FormClosed += CloseOrderForm;
            _orderForm.Show();
        }

        // 關閉order form的事件
        private void CloseOrderForm(object sender, EventArgs e)
        {
            _presentationModel.CloseOrderForm();
        }

        // Inventory Button的click事件
        private void ClickInventoryButton(object sender, EventArgs e)
        {
            _presentationModel.ClickInventoryButton();
            _inventoryForm = new InventoryForm(new InventoryPresentationModel(_orderModel), _orderModel);
            _inventoryForm.FormClosed += CloseInventoryForm;
            _inventoryForm.Show();
        }

        // 關閉inventory form的事件
        private void CloseInventoryForm(object sender, EventArgs e)
        {
            _presentationModel.CloseInventoryForm();
        }

        // Product manage Button的click事件
        private void ClickProductManageButton(object sender, EventArgs e)
        {
            _presentationModel.ClickProductManageButton();
            _productManageForm = new ProductManageForm(new ProductManagePresentationModel(_orderModel), _orderModel);
            _productManageForm.FormClosed += CloseProductManageForm;
            _productManageForm.Show();
        }

        // 關閉product manage form的事件
        private void CloseProductManageForm(object sender, EventArgs e)
        {
            _presentationModel.CloseProductManageForm();
        }

        // Exit Button的click事件
        private void ClickExitButton(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        // 初始化
        private void CreateUserInterface()
        {
            CreateMenu();
            CreateExit();
            AddButtonsToControl();
        }

        // 創建menu
        private void CreateMenu()
        {
            _menuButtons.Add(CreateEachMenuButton(ORDER_SYSTEM_TITLE));
            _menuButtons.Add(CreateEachMenuButton(INVENTORY_SYSTEM_TITLE));
            _menuButtons.Add(CreateEachMenuButton(PRODUCT_MANAGE_SYSTEM_TITLE));
        }

        // 創建exit button
        private void CreateExit()
        {
            _exitButton = new Button();
            SetExitButtonDetail();
        }

        // 將button加入control內
        private void AddButtonsToControl()
        {
            foreach (Button menuButton in _menuButtons)
            {
                Controls.Add(menuButton);
            }
            Controls.Add(_exitButton);
        }

        // 創建單個menu button
        private Button CreateEachMenuButton(string title)
        {
            Button menuButton = new Button();
            menuButton.Text = title;
            menuButton.Font = new Font(TYPE, MENU_TYPE_SIZE, FontStyle.Bold);
            menuButton.Size = new Size(MENU_BUTTON_WIDTH, MENU_BUTTON_HEIGHT);
            menuButton.Location = new System.Drawing.Point(UI_INTERVAL, _presentationModel.GetMarginTop(_menuButtons.Count));
            return menuButton;
        }

        // 設定exit button的細節
        private void SetExitButtonDetail()
        {
            _exitButton.Text = "Exit";
            _exitButton.Size = new Size(EXIT_BUTTON_WIDTH, EXIT_BUTTON_HEIGHT);
            _exitButton.Font = new Font(TYPE, EXIT_TYPE_SIZE, FontStyle.Bold);
            int marginLeft = UI_INTERVAL + MENU_BUTTON_WIDTH - EXIT_BUTTON_WIDTH;
            _exitButton.Location = new System.Drawing.Point(marginLeft, _presentationModel.GetMarginTop(_menuButtons.Count));
        }

        // 給予事件
        private void GiveEvents()
        {
            GiveObserverEvent();
            GiveButtonsEvent();
        }

        // 給予obsever event
        private void GiveObserverEvent()
        {
            FormClosing += CloseForm;
            _presentationModel._presentationModelChanged += RefreshControls;
        }

        // 給予按鈕event
        private void GiveButtonsEvent()
        {
            _menuButtons[(int)MenuList.Order].Click += ClickOrderButton;
            _menuButtons[(int)MenuList.Inventory].Click += ClickInventoryButton;
            _menuButtons[(int)MenuList.ProductManage].Click += ClickProductManageButton;
            _exitButton.Click += ClickExitButton;
        }

        // 刷新UI
        private void RefreshControls()
        {
            _menuButtons[(int)MenuList.Order].Enabled = _presentationModel.IsOrderButtonEnable;
            _menuButtons[(int)MenuList.Inventory].Enabled = _presentationModel.IsInventoryButtonEnable;
            _menuButtons[(int)MenuList.ProductManage].Enabled = _presentationModel.IsProductManageButtonEnable;
        }
    }
}
