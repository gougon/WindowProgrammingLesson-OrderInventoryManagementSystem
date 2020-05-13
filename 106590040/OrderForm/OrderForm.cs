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
    public partial class OrderForm : Form
    {
        public const int EACH_TAB_COUNT = 6;
        public const int BUTTON_EDGE = 90;
        public const int BUTTON_INTERVAL = 10;
        public const int BUTTON_ROW_COUNT = 3;
        public const int BUTTON_COLUMN_COUNT = 2;
        const int DATA_GRID_VIEW_NAME_ORDER = 1;
        const int DATA_GRID_VIEW_CATEGORY_ORDER = 2;
        const int DATA_GRID_VIEW_PRICE_ORDER = 3;
        const int DATA_GRID_VIEW_AMOUNT_ORDER = 4;
        const int DATA_GRID_VIEW_TOTAL_PRICE_ORDER = 5;
        private OrderModel _model;
        private OrderPresentationModel _presentationModel;
        private List<TabPage> _categoryTabPage = new List<TabPage>();
        private List<List<ProductButton>> _productButton = new List<List<ProductButton>>();

        // orderForm的constructor
        public OrderForm(OrderPresentationModel presentationModel, OrderModel model)
        {
            InitializeComponent();
            _model = model;
            _presentationModel = presentationModel;
            Initialize();
            GiveEvents();
        }

        // 視窗關閉事件
        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            _model._modelChanged -= RefreshControls;
            _model._productChanged -= RefreshProducts;
            _presentationModel._presentationModelChanged -= RefreshControls;
        }

        // 初始化
        private void Initialize()
        {
            CreateProductButton();
            _presentationModel.SetChangePageButtonsEnable(_productTabControl.SelectedIndex);
            _pageLabel.Text = _presentationModel.GetPageText(_productTabControl.SelectedIndex);
            RefreshControls();
        }

        // 給予UI event
        private void GiveEvents()
        {
            GiveObserverEvents();
            GiveTabControlEvents();
            GiveButtonEvents();
            GiveDataGridViewEvents();
        }

        // 給予observer的event
        private void GiveObserverEvents()
        {
            FormClosing += CloseForm;
            _model._modelChanged += RefreshControls;
            _model._productChanged += RefreshProducts;
            _presentationModel._presentationModelChanged += RefreshControls;
        }

        // 給予tabcontrol event
        private void GiveTabControlEvents()
        {
            _productTabControl.Selected += ChangeProductTabControlSelected;
        }

        // 給予button event
        private void GiveButtonEvents()
        {
            _backButton.Click += ClickBackButton;
            _nextButton.Click += ClickNextButton;
            _plusProductButton.Click += ClickPlusButton;
            _orderButton.Click += ClickOrderButton;
        }

        // 給予dgv event
        private void GiveDataGridViewEvents()
        {
            _orderDataGridView.CellPainting += AddDeleteButton;
            _orderDataGridView.CellContentClick += DeleteOrderFromDataGridView;
            _orderDataGridView.CellValueChanged += UpdateOrderAmount;
        }

        // 創造商品的介面
        private void CreateProductButton()
        {
            CreateWholeTabPage();
            CreateWholeButton();
        }

        // 重新刷新介面
        private void RefreshControls()
        {
            _pageLabel.Text = _presentationModel.GetPageText(_productTabControl.SelectedIndex);
            _presentationModel.SetChangePageButtonsEnable(_productTabControl.SelectedIndex);
            _plusProductButton.Enabled = _presentationModel.IsPlusProductButtonEnable;
            _nextButton.Enabled = _presentationModel.IsNextButtonEnable;
            _backButton.Enabled = _presentationModel.IsBackButtonEnable;
            _orderButton.Enabled = _presentationModel.IsOrderButtonEnable;
            _totalPriceLabel.Text = _presentationModel.TotalPrice;
            UpdateDataGridViewRows();
        }

        // 產品修改時刷新介面
        private void RefreshProducts()
        {
            _presentationModel.RefreshProducts();
            ClearTabPage();
            CreateWholeTabPage();
            CreateWholeButton();
            _presentationModel.SetChangePageButtonsEnable(_productTabControl.SelectedIndex);
            _pageLabel.Text = _presentationModel.GetPageText(_productTabControl.SelectedIndex);
            RefreshControls();
            UpdateDataGridViewRows();
        }

        // 清除 tab page
        private void ClearTabPage()
        {
            _presentationModel.ClearProductButton();
            _productTabControl.Controls.Clear();
            _categoryTabPage.Clear();
        }

        // 刷新dgv的價格
        private void UpdateDataGridViewRows()
        {
            for (int rowCount = 0; rowCount < _model.OrderCount; rowCount++)
            {
                UpdateDataGridViewRow(rowCount);
            }
        }

        // 刷新單排dgv的價格
        private void UpdateDataGridViewRow(int rowIndex)
        {
            DataGridViewRow row = _orderDataGridView.Rows[rowIndex];
            object name = _model.GetNameFromOrderIndex(rowIndex);
            object amount = row.Cells[DATA_GRID_VIEW_AMOUNT_ORDER].Value;
            _orderDataGridView.Rows[rowIndex].Cells[DATA_GRID_VIEW_NAME_ORDER].Value = name;
            _orderDataGridView.Rows[rowIndex].Cells[DATA_GRID_VIEW_CATEGORY_ORDER].Value = _presentationModel.GetOrderCategory(name.ToString());
            _orderDataGridView.Rows[rowIndex].Cells[DATA_GRID_VIEW_PRICE_ORDER].Value = _presentationModel.GetOrderPrice(name.ToString());
            _orderDataGridView.Rows[rowIndex].Cells[DATA_GRID_VIEW_TOTAL_PRICE_ORDER].Value = _presentationModel.GetProductTotalPrice(name.ToString(), int.Parse(amount.ToString()));
        }
    }
}
