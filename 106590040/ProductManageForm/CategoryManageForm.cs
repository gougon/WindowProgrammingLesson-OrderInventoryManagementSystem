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
        const string MODIFY_CATEGORY_TITLE = "類別";
        const string ADD_CATEGORY_TITLE = "新增類別";

        // 讀入 cateogries 到 list box
        private void LoadCategoriesToListBox()
        {
            for (int serialNumber = 0; serialNumber < _model.CategoryCount; serialNumber++)
            {
                LoadCategoryToListBox(serialNumber);
            }
        }

        // 讀入 category name 到 list box
        private void LoadCategoryToListBox(int category)
        {
            _categoryListBox.Items.Add(_model.GetProductCategoryName(category));
        }

        // 按下 AddCategory button 的事件
        private void ClickAddCategoryButton(object sender, EventArgs e)
        {
            _presentationModel.ClickAddCategoryButton();
            _categoryNameTextBox.Text = "";
            _productsTextBox.Text = "";
        }

        // 按下 list box 的 category 事件
        private void SelectCategoryItem(object sender, EventArgs e)
        {
            _categoryNameTextBox.Text = (string)_categoryListBox.SelectedItem;
            _presentationModel.SelectCategoryItem();
        }

        // name text box 的 key up 事件
        private void KeyUpInCategoryNameTextBox(object sender, EventArgs e)
        {
            _presentationModel.ConfirmCategoryName(_categoryNameTextBox.Text);
        }

        // 按下 modify category button 的事件
        private void ClickModifyCategoryButton(object sender, EventArgs e)
        {
            _categoryListBox.SelectedIndex = -1;
            _presentationModel.AddCategory(_categoryNameTextBox.Text);
        }

        // 清除category info
        private void ClearCategoryInfo()
        {
            _categoryNameTextBox.Text = "";
            _productsTextBox.Text = "";
        }
    }
}