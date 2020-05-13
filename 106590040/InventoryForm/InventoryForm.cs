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
    public partial class InventoryForm : Form
    {
        const int REPLENISHMENT_BUTTON_ORDER = 4;
        const int NAME_ORDER = 0;
        const string REPLENISHMENT_IMAGE_PATH = "../../../Image/icon/replenishment.png";
        private OrderModel _model;
        private InventoryPresentationModel _presentationModel;

        // constructor
        public InventoryForm(InventoryPresentationModel presentationModel, OrderModel model)
        {
            InitializeComponent();
            _model = model;
            _presentationModel = presentationModel;
            Initialize();
            GiveEvents();
        }

        // 在dgv上創建補貨按鈕
        private void AddReplenishmentButton(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == REPLENISHMENT_BUTTON_ORDER)
            {
                Image image = Image.FromFile(REPLENISHMENT_IMAGE_PATH);
                System.Drawing.Point location = new System.Drawing.Point(e.CellBounds.Left, e.CellBounds.Top);
                System.Drawing.Point imageSize = new System.Drawing.Point(image.Width, image.Height);
                System.Drawing.Point cellSize = new System.Drawing.Point(e.CellBounds.Width, e.CellBounds.Height);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.DrawImage(image, new DataGridViewSetting().GetDeleteRectangle(location, imageSize, cellSize));
                e.Handled = true;
            }
        }

        // dgv的click事件(變更圖片、文字)
        private void ChangeProductInformation(object sender, DataGridViewCellEventArgs e)
        {
            object name = _productDataGridView.Rows[e.RowIndex].Cells[NAME_ORDER].Value;
            Point categoryAndIndex = _model.GetCategoryAndIndexFromName(name.ToString());
            SetProductInformation(categoryAndIndex);
        }

        // 按下補貨button
        private void ClickReplenishmentButton(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == REPLENISHMENT_BUTTON_ORDER)
            {
                object name = _productDataGridView.Rows[e.RowIndex].Cells[NAME_ORDER].Value;
                Point categoryAndIndex = _model.GetCategoryAndIndexFromName(name.ToString());
                ReplenishmentForm replenishmentForm = new ReplenishmentForm(new ReplenishmentPresentationModel(_model), _model, categoryAndIndex);
                replenishmentForm.ShowDialog();
            }
        }

        // 視窗關閉事件
        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            _model._modelChanged -= RefreshControls;
            _model._productChanged -= RefreshControls;
        }

        // 給予events
        private void GiveEvents()
        {
            GiveObserverEvents();
            GiveDataGridViewEvents();
        }

        // 給予observer的事件
        private void GiveObserverEvents()
        {
            FormClosing += CloseForm;
            _model._modelChanged += RefreshControls;
            _model._productChanged += RefreshControls;
        }

        // 給予dgv的事件
        private void GiveDataGridViewEvents()
        {
            _productDataGridView.CellPainting += AddReplenishmentButton;
            _productDataGridView.CellClick += ChangeProductInformation;
            _productDataGridView.CellContentClick += ClickReplenishmentButton;
        }

        // 初始化
        private void Initialize()
        {
            SetDataGridView();
            InitializeProductInformation();
        }

        // 從model取得product資訊並顯示在dgv上
        private void SetDataGridView()
        {
            for (int category = 0; category < _model.CategoryCount; ++category)
            {
                SetEachCategoryDataGridView(category);
            }
        }

        // 從 model 取得單個 category 的 product 資訊並顯示在 dgv 上
        private void SetEachCategoryDataGridView(int category)
        {
            for (int index = 0; index < _model.GetProductCount(category); ++index)
            {
                _productDataGridView.Rows.Add(SetDataGridViewRow(category, index));
            }
        }

        // 設定dgv的單個row
        private DataGridViewRow SetDataGridViewRow(int category, int index)
        {
            Product product = _model.GetProduct(category, index);
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell name = new DataGridViewTextBoxCell();
            name.Value = product.Name;
            DataGridViewTextBoxCell chineseCategory = new DataGridViewTextBoxCell();
            chineseCategory.Value = _model.GetProductCategoryName(category);
            DataGridViewTextBoxCell price = new DataGridViewTextBoxCell();
            price.Value = _presentationModel.GetStandardPrice(product.Price);
            DataGridViewTextBoxCell stockAmount = new DataGridViewTextBoxCell();
            stockAmount.Value = product.StockAmount;
            row.Cells.Add(name);
            row.Cells.Add(chineseCategory);
            row.Cells.Add(price);
            row.Cells.Add(stockAmount);
            return row;
        }

        // 初始化商品資訊
        private void InitializeProductInformation()
        {
            object name = _productDataGridView.Rows[0].Cells[NAME_ORDER].Value;
            Point categoryAndIndex = _model.GetCategoryAndIndexFromName(name.ToString());
            _imagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            SetProductInformation(categoryAndIndex);
        }

        // 設定商品資訊
        private void SetProductInformation(Point categoryAndIndex)
        {
            _imagePictureBox.Image = Image.FromFile(_model.GetImagePath(categoryAndIndex.Category, categoryAndIndex.Index));
            _descriptionTextBox.Text = _model.GetDescription(categoryAndIndex.Category, categoryAndIndex.Index);
        }

        // 刷新介面
        private void RefreshControls()
        {
            _productDataGridView.Rows.Clear();
            SetDataGridView();
        }
    }
}
