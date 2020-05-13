namespace _OrderApp
{
    partial class InventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._titleLabel = new System.Windows.Forms.Label();
            this._productDataGridView = new System.Windows.Forms.DataGridView();
            this._nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._categoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._unitPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._replenishmentColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._imageLabel = new System.Windows.Forms.Label();
            this._imagePictureBox = new System.Windows.Forms.PictureBox();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._descriptionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._productDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _titleLabel
            // 
            this._titleLabel.AutoSize = true;
            this._titleLabel.Font = new System.Drawing.Font("微軟正黑體", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._titleLabel.Location = new System.Drawing.Point(315, 25);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(230, 45);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "庫存管理系統";
            // 
            // _productDataGridView
            // 
            this._productDataGridView.AllowUserToAddRows = false;
            this._productDataGridView.AllowUserToDeleteRows = false;
            this._productDataGridView.AllowUserToResizeColumns = false;
            this._productDataGridView.AllowUserToResizeRows = false;
            this._productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._nameColumn,
            this._categoryColumn,
            this._unitPriceColumn,
            this._amountColumn,
            this._replenishmentColumn});
            this._productDataGridView.Location = new System.Drawing.Point(9, 82);
            this._productDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._productDataGridView.Name = "_productDataGridView";
            this._productDataGridView.ReadOnly = true;
            this._productDataGridView.RowHeadersVisible = false;
            this._productDataGridView.RowTemplate.Height = 27;
            this._productDataGridView.Size = new System.Drawing.Size(522, 522);
            this._productDataGridView.TabIndex = 1;
            // 
            // _nameColumn
            // 
            this._nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._nameColumn.FillWeight = 30F;
            this._nameColumn.HeaderText = "商品名稱";
            this._nameColumn.Name = "_nameColumn";
            // 
            // _categoryColumn
            // 
            this._categoryColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._categoryColumn.FillWeight = 20F;
            this._categoryColumn.HeaderText = "商品類別";
            this._categoryColumn.Name = "_categoryColumn";
            // 
            // _unitPriceColumn
            // 
            this._unitPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._unitPriceColumn.FillWeight = 20F;
            this._unitPriceColumn.HeaderText = "單價";
            this._unitPriceColumn.Name = "_unitPriceColumn";
            // 
            // _amountColumn
            // 
            this._amountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._amountColumn.FillWeight = 20F;
            this._amountColumn.HeaderText = "數量";
            this._amountColumn.Name = "_amountColumn";
            // 
            // _replenishmentColumn
            // 
            this._replenishmentColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._replenishmentColumn.FillWeight = 20F;
            this._replenishmentColumn.HeaderText = "補貨";
            this._replenishmentColumn.Name = "_replenishmentColumn";
            // 
            // _imageLabel
            // 
            this._imageLabel.AutoSize = true;
            this._imageLabel.Location = new System.Drawing.Point(543, 101);
            this._imageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._imageLabel.Name = "_imageLabel";
            this._imageLabel.Size = new System.Drawing.Size(56, 12);
            this._imageLabel.TabIndex = 2;
            this._imageLabel.Text = "商品圖片:";
            // 
            // _imagePictureBox
            // 
            this._imagePictureBox.Location = new System.Drawing.Point(545, 115);
            this._imagePictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._imagePictureBox.Name = "_imagePictureBox";
            this._imagePictureBox.Size = new System.Drawing.Size(264, 191);
            this._imagePictureBox.TabIndex = 3;
            this._imagePictureBox.TabStop = false;
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(545, 329);
            this._descriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(56, 12);
            this._descriptionLabel.TabIndex = 4;
            this._descriptionLabel.Text = "商品介紹:";
            // 
            // _descriptionTextBox
            // 
            this._descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._descriptionTextBox.Location = new System.Drawing.Point(548, 343);
            this._descriptionTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._descriptionTextBox.Multiline = true;
            this._descriptionTextBox.Name = "_descriptionTextBox";
            this._descriptionTextBox.ReadOnly = true;
            this._descriptionTextBox.Size = new System.Drawing.Size(262, 262);
            this._descriptionTextBox.TabIndex = 5;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 614);
            this.Controls.Add(this._descriptionTextBox);
            this.Controls.Add(this._descriptionLabel);
            this.Controls.Add(this._imagePictureBox);
            this.Controls.Add(this._imageLabel);
            this.Controls.Add(this._productDataGridView);
            this.Controls.Add(this._titleLabel);
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this._productDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._imagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.DataGridView _productDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _categoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _unitPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _amountColumn;
        private System.Windows.Forms.DataGridViewButtonColumn _replenishmentColumn;
        private System.Windows.Forms.Label _imageLabel;
        private System.Windows.Forms.PictureBox _imagePictureBox;
        private System.Windows.Forms.Label _descriptionLabel;
        private System.Windows.Forms.TextBox _descriptionTextBox;
    }
}