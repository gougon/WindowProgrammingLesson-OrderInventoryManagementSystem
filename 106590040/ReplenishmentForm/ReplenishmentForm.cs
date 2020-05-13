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
    public partial class ReplenishmentForm : Form
    {
        private OrderModel _model;
        private ReplenishmentPresentationModel _presentationModel;
        private Point _categoryAndIndex;

        public ReplenishmentForm(ReplenishmentPresentationModel presentationModel, OrderModel model, Point categoryAndIndex)
        {
            InitializeComponent();
            _model = model;
            _presentationModel = presentationModel;
            _categoryAndIndex = categoryAndIndex;
            Initialize();
            GiveEvents();
        }

        // 按下確認button
        public void ClickConfirmButton(object sender, EventArgs e)
        {
            _model.UpdateProductStock(_categoryAndIndex.Category, _categoryAndIndex.Index, int.Parse(_replenishmentTextBox.Text));
            this.Close();
        }

        // 按下取消button
        public void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }

        // 輸入補貨數量
        public void PressKeyInReplenishmentTextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = !_presentationModel.IsNumber(e.KeyChar);
        }

        // 視窗關閉事件
        public void CloseForm(object sender, FormClosingEventArgs e)
        {
            _model._modelChanged -= RefreshControls;
        }

        // 初始化
        private void Initialize()
        {
            InitializeText();
        }

        // 給予事件
        private void GiveEvents()
        {
            FormClosing += CloseForm;
            _model._modelChanged += RefreshControls;
            _replenishmentTextBox.KeyPress += PressKeyInReplenishmentTextBox;
            _confirmButton.Click += ClickConfirmButton;
            _cancelButton.Click += ClickCancelButton;
        }

        // 初始化文字
        private void InitializeText()
        {
            _nameLabel.Text = _presentationModel.GetNameText(_categoryAndIndex.Category, _categoryAndIndex.Index);
            _categoryLabel.Text = _model.GetProductCategoryName(_categoryAndIndex.Category);
            _priceLabel.Text = _presentationModel.GetPriceText(_categoryAndIndex.Category, _categoryAndIndex.Index);
            _stockAmountLabel.Text = _presentationModel.GetStockAmountText(_categoryAndIndex.Category, _categoryAndIndex.Index);
        }

        // 刷新ui
        private void RefreshControls()
        {
            _stockAmountLabel.Text = _presentationModel.GetStockAmountText(_categoryAndIndex.Category, _categoryAndIndex.Index);
        }
    }
}
