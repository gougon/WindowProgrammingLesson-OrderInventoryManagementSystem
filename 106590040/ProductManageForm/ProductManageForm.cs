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
        const string OPEN = "開啟";
        const string IMAGE_FILTER = "JPG檔案(*.jpg)|*.jpg";
        const string ADD_PRODUCT_TITLE = "新增商品";
        const string MODIFY_PRODUCT_TITLE = "編輯產品";
        const string ADD_BUTTON_TEXT = "新增";
        const string MODIFY_BUTTON_TEXT = "儲存";

        // 讀入products到list box
        private void LoadProductsToListBox()
        {
            for (int category = 0; category < Categories.CATEGORY_COUNT; category++)
            {
                for (int index = 0; index < _model.GetProductCount(category); index++)
                {
                    LoadProductToListBox(category, index);
                }
            }
        }

        // 讀入product到list box
        private void LoadProductToListBox(int category, int index)
        {
            _productListBox.Items.Add(_model.GetName(category, index));
        }

        // 讀入 categories 到 combo box
        private void LoadCategoriesToComboBox()
        {
            for (int count = 0; count < _model.CategoryCount; count++)
            {
                LoadCategoryToComboBox(count);
            }
        }

        // 加入 name 到 categoryComboBox
        private void LoadCategoryToComboBox(int count)
        {
            _categoryComboBox.Items.Add(_model.GetProductCategoryName(count));
        }

        // 點擊lsit box裡面的item，右側資訊隨之變化
        private void SelectProductItem(object sender, EventArgs e)
        {
            _presentationModel.SelectProductItem();
        }

        // 驗證name textbox內的內容
        private void KeyUpInProductNameTextBox(object sender, EventArgs e)
        {
            if (_productListBox.SelectedIndex >= 0)
            {
                _presentationModel.ConfirmName(GetProductNameFromListBox(), _productNameTextBox.Text);
            }
            else if (_presentationModel.EditType == EditType.Add)
            {
                _presentationModel.ConfirmName("", _productNameTextBox.Text);
            }
        }

        // 驗證price textbox內的內容
        private void KeyUpInPriceTextBox(object sender, EventArgs e)
        {
            if (_productListBox.SelectedIndex >= 0)
            {
                _presentationModel.ConfirmPrice(GetProductNameFromListBox(), _priceTextBox.Text);
            }
            else if (_presentationModel.EditType == EditType.Add)
            {
                _presentationModel.ConfirmPrice("", _priceTextBox.Text);
            }
        }

        // 驗證price textbox的輸入
        private void PressKeyInPriceTextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = !_presentationModel.PriceRule(e.KeyChar);
        }

        // 驗證path textbox內的內容
        private void KeyUpInPathTextBox(object sender, EventArgs e)
        {
            if (_productListBox.SelectedIndex >= 0)
            {
                _presentationModel.ConfirmPath(GetProductNameFromListBox(), _imagePathTextBox.Text);
            }
            else if (_presentationModel.EditType == EditType.Add)
            {
                _presentationModel.ConfirmPath("", _imagePathTextBox.Text);
            }
        }

        // 驗證description textbox內的內容
        private void KeyUpInDescriptionTextBox(object sender, EventArgs e)
        {
            if (_productListBox.SelectedIndex >= 0)
            {
                _presentationModel.ConfirmDescription(GetProductNameFromListBox(), _descriptionTextBox.Text);
            }
            else if (_presentationModel.EditType == EditType.Add)
            {
                _presentationModel.ConfirmDescription("", _descriptionTextBox.Text);
            }
        }

        // 驗證category combobox內的內容
        private void SelectChangeInCategoryComboBox(object sender, EventArgs e)
        {
            if (_productListBox.SelectedIndex >= 0)
            {
                _presentationModel.ConfirmCategory(GetProductNameFromListBox(), _categoryComboBox.SelectedIndex);
            }
            else if (_presentationModel.EditType == EditType.Add)
            {
                _presentationModel.ConfirmCategory("", _categoryComboBox.SelectedIndex);
            }
        }

        // 點擊瀏覽按鈕，開啟file dialog
        private void ClickBrowseButton(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = OPEN;
            dialog.Filter = IMAGE_FILTER;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = _presentationModel.GetRelativePath(dialog.FileName);
                _imagePathTextBox.Text = filePath;
                if (_productListBox.SelectedIndex >= 0)
                {
                    _presentationModel.ConfirmPath(GetProductNameFromListBox(), _imagePathTextBox.Text);
                }
                else
                {
                    _presentationModel.ConfirmPath("", _imagePathTextBox.Text);
                }
            }
        }

        // 點擊add button事件
        private void ClickAddProductButton(object sender, EventArgs e)
        {
            ClearProductInfo();
            _editGroupBox.Text = ADD_PRODUCT_TITLE;
            _modifyProductButton.Text = ADD_BUTTON_TEXT;
            _presentationModel.ConfirmName("", "");
            _presentationModel.ConfirmPrice("", "");
            _presentationModel.ConfirmPath("", "");
            _presentationModel.ConfirmCategory("", -1);
            _presentationModel.ConfirmDescription("", "");
            _presentationModel.ClickAddProductButton();
        }

        // 點擊modify button事件
        private void ClickModifyProductButton(object sender, EventArgs e)
        {
            int selectedIndex = _productListBox.SelectedIndex;
            string name = _productNameTextBox.Text;
            ProductInfo info = new ProductInfo();
            SetProductInfo(ref info);
            if (_presentationModel.EditType == EditType.Modify)
            {
                ModifyProduct(name, info);
            }
            else
            {
                AddProduct(name, info);
            }
            _productListBox.SelectedIndex = -1;
            ClearProductInfo();
        }

        // 清除 product 資訊
        private void ClearProductInfo()
        {
            _productNameTextBox.Text = "";
            _priceTextBox.Text = "";
            _categoryComboBox.SelectedIndex = -1;
            _imagePathTextBox.Text = "";
            _descriptionTextBox.Text = "";
        }

        // 儲存產品事件
        private void ModifyProduct(string name, ProductInfo info)
        {
            _presentationModel.ModifyProduct(GetProductNameFromListBox(), _categoryComboBox.SelectedIndex, name, info);
        }

        // 新增產品事件
        private void AddProduct(string name, ProductInfo info)
        {
            _modifyProductButton.Text = MODIFY_BUTTON_TEXT;
            _presentationModel.AddProduct(_categoryComboBox.SelectedIndex, name, info);
        }

        // 設定info數值
        private void SetProductInfo(ref ProductInfo info)
        {
            string description = _descriptionTextBox.Text;
            string imagePath = _presentationModel.GetPathWithParent(_imagePathTextBox.Text);
            int price = int.Parse(_priceTextBox.Text);
            info.SetAll(description, imagePath, price);
        }

        // 找出list box的name
        private string GetProductNameFromListBox()
        {
            return _productListBox.SelectedItem.ToString();
        }
    }
}