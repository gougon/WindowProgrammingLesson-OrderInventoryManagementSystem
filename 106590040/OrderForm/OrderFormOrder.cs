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
        const string DELETE_IMAGE_PATH = "../../../Image/icon/delete.png";
        const string MESSAGE_TITLE = "庫存狀態";
        const string MESSAGE_CONTENT = "庫存不足";

        // 在dgv中加入刪除button
        private void AddDeleteButton(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                Image image = Image.FromFile(DELETE_IMAGE_PATH);
                System.Drawing.Point location = new System.Drawing.Point(e.CellBounds.Left, e.CellBounds.Top);
                System.Drawing.Point imageSize = new System.Drawing.Point(image.Width, image.Height);
                System.Drawing.Point cellSize = new System.Drawing.Point(e.CellBounds.Width, e.CellBounds.Height);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.DrawImage(Image.FromFile(DELETE_IMAGE_PATH), new DataGridViewSetting().GetDeleteRectangle(location, imageSize, cellSize));
                e.Handled = true;
            }
        }

        // 按下刪除按鈕
        private void DeleteOrderFromDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _orderDataGridView.Rows.RemoveAt(e.RowIndex);
                _presentationModel.DeleteOrderProduct(e.RowIndex);
            }
        }

        // 改變訂購數量
        private void UpdateOrderAmount(object sender, DataGridViewCellEventArgs e)
        {
            object amount = _orderDataGridView.Rows[e.RowIndex].Cells[DATA_GRID_VIEW_AMOUNT_ORDER].Value;
            if (_presentationModel.CanOrder(e.RowIndex, int.Parse(amount.ToString())))
            {
                object name = _orderDataGridView.Rows[e.RowIndex].Cells[DATA_GRID_VIEW_NAME_ORDER].Value;
                _model.UpdateOrderAmount(e.RowIndex, int.Parse(amount.ToString()));
            }
            else
            {
                MessageBox.Show(MESSAGE_CONTENT, MESSAGE_TITLE);
                _orderDataGridView.Rows[e.RowIndex].Cells[DATA_GRID_VIEW_AMOUNT_ORDER].Value = _model.GetProductStockFromOrder(e.RowIndex);
            }
        }

        // 加入訂單button被按下
        private void ClickPlusButton(object sender, EventArgs e)
        {
            Product focusProduct = _model.GetFocusProduct();
            _orderDataGridView.Rows.Add(new object[] { null, focusProduct.Name, _model.GetProductCategoryName(_productTabControl.SelectedIndex), new PriceConverter(focusProduct.Price).StandardDollar, 1, new PriceConverter(focusProduct.Price).StandardDollar });
            _presentationModel.ClickPlusButton();
        }

        // 訂購button被按下
        private void ClickOrderButton(object sender, EventArgs e)
        {
            CreditCardPaymentForm creditCardPaymentForm = new CreditCardPaymentForm(new CreditCardPaymentPresentationModel(_model), _model);
            creditCardPaymentForm.ShowDialog();
            if (_model.IsOrderListEmpty)
            {
                _orderDataGridView.Rows.Clear();
            }
        }
    }
}
