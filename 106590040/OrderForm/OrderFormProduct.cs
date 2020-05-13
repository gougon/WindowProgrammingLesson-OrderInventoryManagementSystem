using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _OrderApp
{
    public partial class OrderForm : Form
    {
        // 產品button被按下
        private void ClickProductButton(object sender, EventArgs e)
        {
            ProductButton productButton = sender as ProductButton;
            _productDetailRichTextBox.Text = _model.GetProductIntroduce(productButton.TabCount, productButton.ButtonCount);
            _productPriceLabel.Text = _presentationModel.GetProductPrice(productButton.TabCount, productButton.ButtonCount);
            _productStockLabel.Text = _presentationModel.GetProductStock(productButton.TabCount, productButton.ButtonCount);
            _presentationModel.ClickProductButton(productButton.TabCount, productButton.ButtonCount);
        }

        // 按下下一頁的按鈕
        private void ClickNextButton(object sender, EventArgs e)
        {
            int tabCount = _productTabControl.SelectedIndex;
            _presentationModel.ClickNextButton(tabCount);
            ChangePage(tabCount);
        }

        // 按下上一頁的按鈕
        private void ClickBackButton(object sender, EventArgs e)
        {
            int tabCount = _productTabControl.SelectedIndex;
            _presentationModel.ClickBackButton(tabCount);
            ChangePage(tabCount);
        }

        // 清空當頁並創造新一頁
        private void ChangePage(int tabCount)
        {
            ClearCurrentPageButton(tabCount);
            CreateEachTabButton(tabCount);
        }

        // button失去focus
        private void LeaveFocusFromButton(object sender, EventArgs e)
        {
            _productDetailRichTextBox.Text = "";
            _productPriceLabel.Text = "";
            _productStockLabel.Text = "";
            _presentationModel.SetLeaveFocusFromProductButton(_plusProductButton.Focused);
        }

        // category tab control換頁的事件
        private void ChangeProductTabControlSelected(object sender, EventArgs e)
        {
            int tabCount = _productTabControl.SelectedIndex;
            if (_productTabControl.TabCount == _model.CategoryCount)
            {
                _presentationModel.ChangeProductTabControlSelected(tabCount);
                ClearCurrentPageButton(tabCount);
                CreateEachTabButton(tabCount);
            }
        }

        // 創建全部的button以及給予大小
        private void CreateWholeButton()
        {
            for (int tabCount = 0; tabCount < _model.CategoryCount; ++tabCount)
            {
                _productButton.Add(new List<ProductButton>());
                CreateEachTabButton(tabCount);
            }
        }

        // 創建全部的tabPage
        private void CreateWholeTabPage()
        {
            for (int tabCount = 0; tabCount < _model.CategoryCount; ++tabCount)
            {
                CreateEachTabPage(tabCount);
            }
        }

        // 創建單的 tabPage
        private void CreateEachTabPage(int tabCount)
        {
            _categoryTabPage.Add(new TabPage(_model.GetProductCategoryName(tabCount)));
            _productTabControl.TabPages.Add(_categoryTabPage[tabCount]);
        }

        // 創建每一個tab的所有button
        private void CreateEachTabButton(int tabCount)
        {
            _presentationModel.CreatePage();
            for (int buttonCount = 0; buttonCount < EACH_TAB_COUNT && !_presentationModel.IsFinalProduct(tabCount); ++buttonCount)
            {
                CreateSingleProductButton(tabCount, buttonCount);
            }
        }

        // 創建一個新的productButton
        private void CreateSingleProductButton(int tabCount, int buttonCount)
        {
            _presentationModel.CreateProductButton(tabCount);
            ProductButton productButton = new ProductButton();
            SetButtonDetail(productButton, tabCount, buttonCount);
            GiveProductButtonEvents(productButton);
            _productButton[tabCount].Add(productButton);
            _categoryTabPage[tabCount].Controls.Add(productButton);
        }

        // 設定button的屬性
        private void SetButtonDetail(ProductButton productButton, int tabCount, int buttonCount)
        {
            productButton.Size = new Size(BUTTON_EDGE, BUTTON_EDGE);
            SetButtonPosition(productButton, buttonCount);
            productButton.TabCount = tabCount;
            productButton.ButtonCount = _presentationModel.GetProductButtonCount(tabCount) - 1;
            SetButtonImage(productButton, tabCount, productButton.ButtonCount);
        }

        // 設定button的Events
        private void GiveProductButtonEvents(Button productButton)
        {
            productButton.Click += ClickProductButton;
            productButton.LostFocus += LeaveFocusFromButton;
        }

        // 設定button的位置
        private void SetButtonPosition(ProductButton productButton, int buttonCount)
        {
            productButton.Location = new System.Drawing.Point(OrderForm.BUTTON_INTERVAL + (buttonCount % OrderForm.BUTTON_ROW_COUNT) * (OrderForm.BUTTON_EDGE + OrderForm.BUTTON_INTERVAL), OrderForm.BUTTON_INTERVAL + (buttonCount / OrderForm.BUTTON_ROW_COUNT) * (OrderForm.BUTTON_EDGE + OrderForm.BUTTON_INTERVAL));
        }

        // 設定button的圖片
        private void SetButtonImage(ProductButton productButton, int tabCount, int buttonCount)
        {
            productButton.BackgroundImageLayout = ImageLayout.Stretch;
            productButton.BackgroundImage = Image.FromFile(_model.GetImagePath(tabCount, buttonCount));
        }

        // 刪除當前頁面的所有button
        private void ClearCurrentPageButton(int tabCount)
        {
            _productButton[tabCount].Clear();
            _categoryTabPage[tabCount].Controls.Clear();
        }
    }
}
