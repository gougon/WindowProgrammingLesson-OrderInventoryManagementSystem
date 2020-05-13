namespace _OrderApp
{
    partial class OrderForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this._productGroupBox = new System.Windows.Forms.GroupBox();
            this._nextButton = new System.Windows.Forms.Button();
            this._backButton = new System.Windows.Forms.Button();
            this._pageLabel = new System.Windows.Forms.Label();
            this._plusProductButton = new System.Windows.Forms.Button();
            this._productDetailGroupBox = new System.Windows.Forms.GroupBox();
            this._productStockLabel = new System.Windows.Forms.Label();
            this._productPriceLabel = new System.Windows.Forms.Label();
            this._productDetailRichTextBox = new System.Windows.Forms.RichTextBox();
            this._productTabControl = new System.Windows.Forms.TabControl();
            this._orderDataGridView = new System.Windows.Forms.DataGridView();
            this._productDeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._productNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._productCategoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._productPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._productAmountColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this._productTotalPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._orderLabel = new System.Windows.Forms.Label();
            this._totalPriceLabel = new System.Windows.Forms.Label();
            this._orderButton = new System.Windows.Forms.Button();
            this._productGroupBox.SuspendLayout();
            this._productDetailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._orderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _productGroupBox
            // 
            this._productGroupBox.Controls.Add(this._nextButton);
            this._productGroupBox.Controls.Add(this._backButton);
            this._productGroupBox.Controls.Add(this._pageLabel);
            this._productGroupBox.Controls.Add(this._plusProductButton);
            this._productGroupBox.Controls.Add(this._productDetailGroupBox);
            this._productGroupBox.Controls.Add(this._productTabControl);
            this._productGroupBox.Location = new System.Drawing.Point(12, 12);
            this._productGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._productGroupBox.Name = "_productGroupBox";
            this._productGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._productGroupBox.Size = new System.Drawing.Size(431, 475);
            this._productGroupBox.TabIndex = 0;
            this._productGroupBox.TabStop = false;
            this._productGroupBox.Text = "商品";
            // 
            // _nextButton
            // 
            this._nextButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_nextButton.BackgroundImage")));
            this._nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._nextButton.Location = new System.Drawing.Point(247, 434);
            this._nextButton.Margin = new System.Windows.Forms.Padding(4);
            this._nextButton.Name = "_nextButton";
            this._nextButton.Size = new System.Drawing.Size(47, 35);
            this._nextButton.TabIndex = 5;
            this._nextButton.UseVisualStyleBackColor = true;
            // 
            // _backButton
            // 
            this._backButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_backButton.BackgroundImage")));
            this._backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._backButton.Enabled = false;
            this._backButton.Location = new System.Drawing.Point(192, 434);
            this._backButton.Margin = new System.Windows.Forms.Padding(4);
            this._backButton.Name = "_backButton";
            this._backButton.Size = new System.Drawing.Size(47, 35);
            this._backButton.TabIndex = 4;
            this._backButton.UseVisualStyleBackColor = true;
            // 
            // _pageLabel
            // 
            this._pageLabel.AutoSize = true;
            this._pageLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._pageLabel.Location = new System.Drawing.Point(7, 436);
            this._pageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(71, 25);
            this._pageLabel.TabIndex = 3;
            this._pageLabel.Text = "label1";
            // 
            // _plusProductButton
            // 
            this._plusProductButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_plusProductButton.BackgroundImage")));
            this._plusProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._plusProductButton.Enabled = false;
            this._plusProductButton.Location = new System.Drawing.Point(321, 434);
            this._plusProductButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._plusProductButton.Name = "_plusProductButton";
            this._plusProductButton.Size = new System.Drawing.Size(103, 35);
            this._plusProductButton.TabIndex = 2;
            this._plusProductButton.UseVisualStyleBackColor = true;
            // 
            // _productDetailGroupBox
            // 
            this._productDetailGroupBox.Controls.Add(this._productStockLabel);
            this._productDetailGroupBox.Controls.Add(this._productPriceLabel);
            this._productDetailGroupBox.Controls.Add(this._productDetailRichTextBox);
            this._productDetailGroupBox.Location = new System.Drawing.Point(5, 324);
            this._productDetailGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._productDetailGroupBox.Name = "_productDetailGroupBox";
            this._productDetailGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._productDetailGroupBox.Size = new System.Drawing.Size(419, 105);
            this._productDetailGroupBox.TabIndex = 1;
            this._productDetailGroupBox.TabStop = false;
            this._productDetailGroupBox.Text = "商品資訊";
            // 
            // _productStockLabel
            // 
            this._productStockLabel.AutoSize = true;
            this._productStockLabel.Location = new System.Drawing.Point(233, 46);
            this._productStockLabel.Name = "_productStockLabel";
            this._productStockLabel.Size = new System.Drawing.Size(0, 15);
            this._productStockLabel.TabIndex = 3;
            // 
            // _productPriceLabel
            // 
            this._productPriceLabel.AutoSize = true;
            this._productPriceLabel.Location = new System.Drawing.Point(233, 88);
            this._productPriceLabel.Name = "_productPriceLabel";
            this._productPriceLabel.Size = new System.Drawing.Size(0, 15);
            this._productPriceLabel.TabIndex = 2;
            // 
            // _productDetailRichTextBox
            // 
            this._productDetailRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._productDetailRichTextBox.Location = new System.Drawing.Point(5, 24);
            this._productDetailRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._productDetailRichTextBox.Name = "_productDetailRichTextBox";
            this._productDetailRichTextBox.ReadOnly = true;
            this._productDetailRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this._productDetailRichTextBox.Size = new System.Drawing.Size(223, 79);
            this._productDetailRichTextBox.TabIndex = 1;
            this._productDetailRichTextBox.Text = "";
            // 
            // _productTabControl
            // 
            this._productTabControl.Location = new System.Drawing.Point(5, 24);
            this._productTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._productTabControl.Name = "_productTabControl";
            this._productTabControl.SelectedIndex = 0;
            this._productTabControl.Size = new System.Drawing.Size(424, 295);
            this._productTabControl.TabIndex = 0;
            // 
            // _orderDataGridView
            // 
            this._orderDataGridView.AllowUserToAddRows = false;
            this._orderDataGridView.AllowUserToDeleteRows = false;
            this._orderDataGridView.AllowUserToResizeColumns = false;
            this._orderDataGridView.AllowUserToResizeRows = false;
            this._orderDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._orderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._orderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._productDeleteColumn,
            this._productNameColumn,
            this._productCategoryColumn,
            this._productPriceColumn,
            this._productAmountColumn,
            this._productTotalPriceColumn});
            this._orderDataGridView.Location = new System.Drawing.Point(461, 62);
            this._orderDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._orderDataGridView.Name = "_orderDataGridView";
            this._orderDataGridView.RowHeadersVisible = false;
            this._orderDataGridView.RowTemplate.Height = 27;
            this._orderDataGridView.Size = new System.Drawing.Size(752, 361);
            this._orderDataGridView.TabIndex = 1;
            // 
            // _productDeleteColumn
            // 
            this._productDeleteColumn.FillWeight = 30F;
            this._productDeleteColumn.HeaderText = "刪除";
            this._productDeleteColumn.Name = "_productDeleteColumn";
            this._productDeleteColumn.ReadOnly = true;
            this._productDeleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._productDeleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _productNameColumn
            // 
            this._productNameColumn.HeaderText = "產品名稱";
            this._productNameColumn.Name = "_productNameColumn";
            this._productNameColumn.ReadOnly = true;
            // 
            // _productCategoryColumn
            // 
            this._productCategoryColumn.FillWeight = 70F;
            this._productCategoryColumn.HeaderText = "產品類別";
            this._productCategoryColumn.Name = "_productCategoryColumn";
            this._productCategoryColumn.ReadOnly = true;
            // 
            // _productPriceColumn
            // 
            this._productPriceColumn.FillWeight = 70F;
            this._productPriceColumn.HeaderText = "單價";
            this._productPriceColumn.Name = "_productPriceColumn";
            this._productPriceColumn.ReadOnly = true;
            // 
            // _productAmountColumn
            // 
            this._productAmountColumn.FillWeight = 70F;
            this._productAmountColumn.HeaderText = "數量";
            this._productAmountColumn.Name = "_productAmountColumn";
            // 
            // _productTotalPriceColumn
            // 
            this._productTotalPriceColumn.FillWeight = 70F;
            this._productTotalPriceColumn.HeaderText = "總價";
            this._productTotalPriceColumn.Name = "_productTotalPriceColumn";
            this._productTotalPriceColumn.ReadOnly = true;
            this._productTotalPriceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._productTotalPriceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _orderLabel
            // 
            this._orderLabel.AutoSize = true;
            this._orderLabel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._orderLabel.Location = new System.Drawing.Point(799, 12);
            this._orderLabel.Name = "_orderLabel";
            this._orderLabel.Size = new System.Drawing.Size(110, 31);
            this._orderLabel.TabIndex = 2;
            this._orderLabel.Text = "我的訂單";
            // 
            // _totalPriceLabel
            // 
            this._totalPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._totalPriceLabel.AutoSize = true;
            this._totalPriceLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._totalPriceLabel.Location = new System.Drawing.Point(987, 445);
            this._totalPriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._totalPriceLabel.Name = "_totalPriceLabel";
            this._totalPriceLabel.Size = new System.Drawing.Size(109, 25);
            this._totalPriceLabel.TabIndex = 3;
            this._totalPriceLabel.Text = "總金額:0元";
            this._totalPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _orderButton
            // 
            this._orderButton.Enabled = false;
            this._orderButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._orderButton.Location = new System.Drawing.Point(853, 434);
            this._orderButton.Margin = new System.Windows.Forms.Padding(4);
            this._orderButton.Name = "_orderButton";
            this._orderButton.Size = new System.Drawing.Size(125, 48);
            this._orderButton.TabIndex = 4;
            this._orderButton.Text = "訂購";
            this._orderButton.UseVisualStyleBackColor = true;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 496);
            this.Controls.Add(this._orderButton);
            this.Controls.Add(this._totalPriceLabel);
            this.Controls.Add(this._orderLabel);
            this.Controls.Add(this._orderDataGridView);
            this.Controls.Add(this._productGroupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrderForm";
            this.Text = "訂購";
            this._productGroupBox.ResumeLayout(false);
            this._productGroupBox.PerformLayout();
            this._productDetailGroupBox.ResumeLayout(false);
            this._productDetailGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._orderDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _productGroupBox;
        private System.Windows.Forms.Button _plusProductButton;
        private System.Windows.Forms.GroupBox _productDetailGroupBox;
        private System.Windows.Forms.Label _productPriceLabel;
        private System.Windows.Forms.RichTextBox _productDetailRichTextBox;
        private System.Windows.Forms.TabControl _productTabControl;
        private System.Windows.Forms.DataGridView _orderDataGridView;
        private System.Windows.Forms.Label _orderLabel;
        private System.Windows.Forms.Label _totalPriceLabel;
        private System.Windows.Forms.Button _nextButton;
        private System.Windows.Forms.Button _backButton;
        private System.Windows.Forms.Label _pageLabel;
        private System.Windows.Forms.Button _orderButton;
        private System.Windows.Forms.Label _productStockLabel;
        private System.Windows.Forms.DataGridViewButtonColumn _productDeleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _productNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _productCategoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _productPriceColumn;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn _productAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _productTotalPriceColumn;
    }
}

