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
    public partial class ProductManageForm : Form
    {
        ProductManagePresentationModel _presentationModel;
        OrderModel _model;

        public ProductManageForm(ProductManagePresentationModel presentationModel, OrderModel model)
        {
            InitializeComponent();
            _presentationModel = presentationModel;
            _model = model;
            Initialize();
            GiveEvents();
            LoadCategoriesToComboBox();
            LoadProductsToListBox();
            LoadCategoriesToListBox();
        }

        // 初始化
        private void Initialize()
        {
            _modifyProductButton.Enabled = false;
            _modifyCategoryButton.Enabled = false;
        }

        // 視窗關閉事件
        private void CloseForm(object sender, EventArgs e)
        {
            _presentationModel._presentationModelChanged -= RefreshControl;
            _presentationModel._listBoxChanged -= RefreshListBox;
        }

        // 切換視窗事件
        private void SelectChangeInTabControl(object sender, EventArgs e)
        {
            _presentationModel.EditType = EditType.Modify;
            ClearProductInfo();
            ClearCategoryInfo();
        }

        // 給予事件
        private void GiveEvents()
        {
            _presentationModel._presentationModelChanged += RefreshControl;
            _presentationModel._listBoxChanged += RefreshListBox;
            FormClosed += CloseForm;
            _productListBox.Click += SelectProductItem;
            _categoryListBox.Click += SelectCategoryItem;
            _addProductButton.Click += ClickAddProductButton;
            _addCategoryButton.Click += ClickAddCategoryButton;
            _browseButton.Click += ClickBrowseButton;
            _modifyProductButton.Click += ClickModifyProductButton;
            _modifyCategoryButton.Click += ClickModifyCategoryButton;
            _productNameTextBox.KeyUp += KeyUpInProductNameTextBox;
            _categoryNameTextBox.KeyUp += KeyUpInCategoryNameTextBox;
            _priceTextBox.KeyUp += KeyUpInPriceTextBox;
            _priceTextBox.KeyPress += PressKeyInPriceTextBox;
            _imagePathTextBox.KeyUp += KeyUpInPathTextBox;
            _descriptionTextBox.KeyUp += KeyUpInDescriptionTextBox;
            _categoryComboBox.SelectedIndexChanged += SelectChangeInCategoryComboBox;
            _managementTabControl.SelectedIndexChanged += SelectChangeInTabControl;
        }

        // 刷新ui
        private void RefreshControl()
        {
            RefreshProductControl();
            RefreshCategoryControl();
        }

        // 刷新 product manage
        private void RefreshProductControl()
        {
            if (_productListBox.Focused)
            {
                _productNameTextBox.Text = GetProductNameFromListBox();
                _priceTextBox.Text = _model.GetProductPrice(GetProductNameFromListBox()).ToString();
                _categoryComboBox.SelectedIndex = GetCategoryAndIndexFromName(GetProductNameFromListBox()).Category;
                _imagePathTextBox.Text = _presentationModel.GetPathWithinParent(GetProductNameFromListBox());
                _descriptionTextBox.Text = _model.GetDescription(GetProductNameFromListBox());
            }
            else
            {
                _modifyProductButton.Enabled = _presentationModel.IsModifyButtonEnable;
                _addProductButton.Enabled = _presentationModel.IsAddProductButtonEnable;
            }
        }

        // 刷新 category manage
        private void RefreshCategoryControl()
        {
            _addCategoryButton.Enabled = !_presentationModel.IsAddCategoryState;
            _modifyCategoryButton.Enabled = _presentationModel.IsModifyCategoryButtonEnable;
            if (!_presentationModel.IsAddCategoryState)
            {
                _categoryGroupBox.Text = MODIFY_CATEGORY_TITLE;
                _productsTextBox.Text = _model.GetCategoryProductsName(_categoryListBox.SelectedIndex);
            }
            else
            {
                _categoryGroupBox.Text = ADD_CATEGORY_TITLE;
            }
        }

        // 刷新listbox
        private void RefreshListBox()
        {
            _productListBox.Items.Clear();
            LoadProductsToListBox();
            _categoryListBox.Items.Clear();
            LoadCategoriesToListBox();
            _categoryComboBox.Items.Clear();
            LoadCategoriesToComboBox();
        }

        // 藉由 name 找到 category and index
        private Point GetCategoryAndIndexFromName(string name)
        {
            return _model.GetCategoryAndIndexFromName(name);
        }
    }
}
