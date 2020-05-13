namespace _OrderApp
{
    partial class ProductManageForm
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
            this._title = new System.Windows.Forms.Label();
            this._managementTabControl = new System.Windows.Forms.TabControl();
            this._productTabPage = new System.Windows.Forms.TabPage();
            this._editGroupBox = new System.Windows.Forms.GroupBox();
            this._browseButton = new System.Windows.Forms.Button();
            this._categoryComboBox = new System.Windows.Forms.ComboBox();
            this._modifyProductButton = new System.Windows.Forms.Button();
            this._descriptionTextBox = new System.Windows.Forms.TextBox();
            this._imagePathTextBox = new System.Windows.Forms.TextBox();
            this._priceTextBox = new System.Windows.Forms.TextBox();
            this._productNameTextBox = new System.Windows.Forms.TextBox();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._imagePathLabel = new System.Windows.Forms.Label();
            this._categoryLabel = new System.Windows.Forms.Label();
            this._moneyLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._productNameLabel = new System.Windows.Forms.Label();
            this._addProductButton = new System.Windows.Forms.Button();
            this._productListBox = new System.Windows.Forms.ListBox();
            this._categoryTabPage = new System.Windows.Forms.TabPage();
            this._categoryGroupBox = new System.Windows.Forms.GroupBox();
            this._modifyCategoryButton = new System.Windows.Forms.Button();
            this._productsTextBox = new System.Windows.Forms.TextBox();
            this._categoryNameTextBox = new System.Windows.Forms.TextBox();
            this._productsLabel = new System.Windows.Forms.Label();
            this._categoryNameLabel = new System.Windows.Forms.Label();
            this._addCategoryButton = new System.Windows.Forms.Button();
            this._categoryListBox = new System.Windows.Forms.ListBox();
            this._managementTabControl.SuspendLayout();
            this._productTabPage.SuspendLayout();
            this._editGroupBox.SuspendLayout();
            this._categoryTabPage.SuspendLayout();
            this._categoryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _title
            // 
            this._title.AutoSize = true;
            this._title.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._title.Location = new System.Drawing.Point(364, 23);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(177, 35);
            this._title.TabIndex = 0;
            this._title.Text = "商品管理系統";
            // 
            // _managementTabControl
            // 
            this._managementTabControl.Controls.Add(this._productTabPage);
            this._managementTabControl.Controls.Add(this._categoryTabPage);
            this._managementTabControl.Location = new System.Drawing.Point(12, 61);
            this._managementTabControl.Name = "_managementTabControl";
            this._managementTabControl.SelectedIndex = 0;
            this._managementTabControl.Size = new System.Drawing.Size(839, 505);
            this._managementTabControl.TabIndex = 1;
            // 
            // _productTabPage
            // 
            this._productTabPage.Controls.Add(this._editGroupBox);
            this._productTabPage.Controls.Add(this._addProductButton);
            this._productTabPage.Controls.Add(this._productListBox);
            this._productTabPage.Location = new System.Drawing.Point(4, 22);
            this._productTabPage.Name = "_productTabPage";
            this._productTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._productTabPage.Size = new System.Drawing.Size(831, 479);
            this._productTabPage.TabIndex = 0;
            this._productTabPage.Text = "商品管理";
            this._productTabPage.UseVisualStyleBackColor = true;
            // 
            // _editGroupBox
            // 
            this._editGroupBox.Controls.Add(this._browseButton);
            this._editGroupBox.Controls.Add(this._categoryComboBox);
            this._editGroupBox.Controls.Add(this._modifyProductButton);
            this._editGroupBox.Controls.Add(this._descriptionTextBox);
            this._editGroupBox.Controls.Add(this._imagePathTextBox);
            this._editGroupBox.Controls.Add(this._priceTextBox);
            this._editGroupBox.Controls.Add(this._productNameTextBox);
            this._editGroupBox.Controls.Add(this._descriptionLabel);
            this._editGroupBox.Controls.Add(this._imagePathLabel);
            this._editGroupBox.Controls.Add(this._categoryLabel);
            this._editGroupBox.Controls.Add(this._moneyLabel);
            this._editGroupBox.Controls.Add(this._priceLabel);
            this._editGroupBox.Controls.Add(this._productNameLabel);
            this._editGroupBox.Location = new System.Drawing.Point(242, 3);
            this._editGroupBox.Name = "_editGroupBox";
            this._editGroupBox.Size = new System.Drawing.Size(583, 476);
            this._editGroupBox.TabIndex = 2;
            this._editGroupBox.TabStop = false;
            this._editGroupBox.Text = "編輯商品";
            // 
            // _browseButton
            // 
            this._browseButton.Location = new System.Drawing.Point(472, 146);
            this._browseButton.Name = "_browseButton";
            this._browseButton.Size = new System.Drawing.Size(105, 22);
            this._browseButton.TabIndex = 11;
            this._browseButton.Text = "瀏覽...";
            this._browseButton.UseVisualStyleBackColor = true;
            // 
            // _categoryComboBox
            // 
            this._categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._categoryComboBox.FormattingEnabled = true;
            this._categoryComboBox.Location = new System.Drawing.Point(357, 90);
            this._categoryComboBox.Name = "_categoryComboBox";
            this._categoryComboBox.Size = new System.Drawing.Size(220, 20);
            this._categoryComboBox.TabIndex = 10;
            // 
            // _modifyProductButton
            // 
            this._modifyProductButton.Location = new System.Drawing.Point(447, 435);
            this._modifyProductButton.Name = "_modifyProductButton";
            this._modifyProductButton.Size = new System.Drawing.Size(130, 38);
            this._modifyProductButton.TabIndex = 3;
            this._modifyProductButton.Text = "儲存";
            this._modifyProductButton.UseVisualStyleBackColor = true;
            // 
            // _descriptionTextBox
            // 
            this._descriptionTextBox.Location = new System.Drawing.Point(8, 225);
            this._descriptionTextBox.Multiline = true;
            this._descriptionTextBox.Name = "_descriptionTextBox";
            this._descriptionTextBox.Size = new System.Drawing.Size(569, 209);
            this._descriptionTextBox.TabIndex = 9;
            // 
            // _imagePathTextBox
            // 
            this._imagePathTextBox.Location = new System.Drawing.Point(103, 146);
            this._imagePathTextBox.Name = "_imagePathTextBox";
            this._imagePathTextBox.Size = new System.Drawing.Size(363, 22);
            this._imagePathTextBox.TabIndex = 8;
            // 
            // _priceTextBox
            // 
            this._priceTextBox.Location = new System.Drawing.Point(79, 90);
            this._priceTextBox.Name = "_priceTextBox";
            this._priceTextBox.Size = new System.Drawing.Size(148, 22);
            this._priceTextBox.TabIndex = 7;
            this._priceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _productNameTextBox
            // 
            this._productNameTextBox.Location = new System.Drawing.Point(79, 34);
            this._productNameTextBox.Name = "_productNameTextBox";
            this._productNameTextBox.Size = new System.Drawing.Size(498, 22);
            this._productNameTextBox.TabIndex = 6;
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(6, 210);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(67, 12);
            this._descriptionLabel.TabIndex = 5;
            this._descriptionLabel.Text = "商品介紹(*)";
            // 
            // _imagePathLabel
            // 
            this._imagePathLabel.AutoSize = true;
            this._imagePathLabel.Location = new System.Drawing.Point(6, 149);
            this._imagePathLabel.Name = "_imagePathLabel";
            this._imagePathLabel.Size = new System.Drawing.Size(91, 12);
            this._imagePathLabel.TabIndex = 4;
            this._imagePathLabel.Text = "商品圖片路徑(*)";
            // 
            // _categoryLabel
            // 
            this._categoryLabel.AutoSize = true;
            this._categoryLabel.Location = new System.Drawing.Point(284, 93);
            this._categoryLabel.Name = "_categoryLabel";
            this._categoryLabel.Size = new System.Drawing.Size(67, 12);
            this._categoryLabel.TabIndex = 3;
            this._categoryLabel.Text = "商品類別(*)";
            // 
            // _moneyLabel
            // 
            this._moneyLabel.AutoSize = true;
            this._moneyLabel.Location = new System.Drawing.Point(233, 93);
            this._moneyLabel.Name = "_moneyLabel";
            this._moneyLabel.Size = new System.Drawing.Size(28, 12);
            this._moneyLabel.TabIndex = 2;
            this._moneyLabel.Text = "NTD";
            // 
            // _priceLabel
            // 
            this._priceLabel.AutoSize = true;
            this._priceLabel.Location = new System.Drawing.Point(6, 93);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(67, 12);
            this._priceLabel.TabIndex = 1;
            this._priceLabel.Text = "商品價格(*)";
            // 
            // _productNameLabel
            // 
            this._productNameLabel.AutoSize = true;
            this._productNameLabel.Location = new System.Drawing.Point(6, 37);
            this._productNameLabel.Name = "_productNameLabel";
            this._productNameLabel.Size = new System.Drawing.Size(67, 12);
            this._productNameLabel.TabIndex = 0;
            this._productNameLabel.Text = "商品名稱(*)";
            // 
            // _addProductButton
            // 
            this._addProductButton.Location = new System.Drawing.Point(0, 438);
            this._addProductButton.Name = "_addProductButton";
            this._addProductButton.Size = new System.Drawing.Size(236, 38);
            this._addProductButton.TabIndex = 1;
            this._addProductButton.Text = "新增商品";
            this._addProductButton.UseVisualStyleBackColor = true;
            // 
            // _productListBox
            // 
            this._productListBox.FormattingEnabled = true;
            this._productListBox.ItemHeight = 12;
            this._productListBox.Location = new System.Drawing.Point(0, 1);
            this._productListBox.Name = "_productListBox";
            this._productListBox.Size = new System.Drawing.Size(236, 436);
            this._productListBox.TabIndex = 0;
            // 
            // _categoryTabPage
            // 
            this._categoryTabPage.Controls.Add(this._categoryGroupBox);
            this._categoryTabPage.Controls.Add(this._addCategoryButton);
            this._categoryTabPage.Controls.Add(this._categoryListBox);
            this._categoryTabPage.Location = new System.Drawing.Point(4, 22);
            this._categoryTabPage.Name = "_categoryTabPage";
            this._categoryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._categoryTabPage.Size = new System.Drawing.Size(831, 479);
            this._categoryTabPage.TabIndex = 1;
            this._categoryTabPage.Text = "類別管理";
            this._categoryTabPage.UseVisualStyleBackColor = true;
            // 
            // _categoryGroupBox
            // 
            this._categoryGroupBox.Controls.Add(this._modifyCategoryButton);
            this._categoryGroupBox.Controls.Add(this._productsTextBox);
            this._categoryGroupBox.Controls.Add(this._categoryNameTextBox);
            this._categoryGroupBox.Controls.Add(this._productsLabel);
            this._categoryGroupBox.Controls.Add(this._categoryNameLabel);
            this._categoryGroupBox.Location = new System.Drawing.Point(242, 3);
            this._categoryGroupBox.Name = "_categoryGroupBox";
            this._categoryGroupBox.Size = new System.Drawing.Size(583, 476);
            this._categoryGroupBox.TabIndex = 3;
            this._categoryGroupBox.TabStop = false;
            this._categoryGroupBox.Text = "類別";
            // 
            // _modifyCategoryButton
            // 
            this._modifyCategoryButton.Location = new System.Drawing.Point(447, 435);
            this._modifyCategoryButton.Name = "_modifyCategoryButton";
            this._modifyCategoryButton.Size = new System.Drawing.Size(130, 38);
            this._modifyCategoryButton.TabIndex = 3;
            this._modifyCategoryButton.Text = "新增";
            this._modifyCategoryButton.UseVisualStyleBackColor = true;
            // 
            // _productsTextBox
            // 
            this._productsTextBox.Location = new System.Drawing.Point(8, 126);
            this._productsTextBox.Multiline = true;
            this._productsTextBox.Name = "_productsTextBox";
            this._productsTextBox.Size = new System.Drawing.Size(569, 308);
            this._productsTextBox.TabIndex = 9;
            // 
            // _categoryNameTextBox
            // 
            this._categoryNameTextBox.Location = new System.Drawing.Point(79, 34);
            this._categoryNameTextBox.Name = "_categoryNameTextBox";
            this._categoryNameTextBox.Size = new System.Drawing.Size(498, 22);
            this._categoryNameTextBox.TabIndex = 6;
            // 
            // _productsLabel
            // 
            this._productsLabel.AutoSize = true;
            this._productsLabel.Location = new System.Drawing.Point(6, 111);
            this._productsLabel.Name = "_productsLabel";
            this._productsLabel.Size = new System.Drawing.Size(65, 12);
            this._productsLabel.TabIndex = 5;
            this._productsLabel.Text = "類別內產品";
            // 
            // _categoryNameLabel
            // 
            this._categoryNameLabel.AutoSize = true;
            this._categoryNameLabel.Location = new System.Drawing.Point(6, 37);
            this._categoryNameLabel.Name = "_categoryNameLabel";
            this._categoryNameLabel.Size = new System.Drawing.Size(67, 12);
            this._categoryNameLabel.TabIndex = 0;
            this._categoryNameLabel.Text = "類別名稱(*)";
            // 
            // _addCategoryButton
            // 
            this._addCategoryButton.Location = new System.Drawing.Point(-1, 438);
            this._addCategoryButton.Name = "_addCategoryButton";
            this._addCategoryButton.Size = new System.Drawing.Size(236, 38);
            this._addCategoryButton.TabIndex = 2;
            this._addCategoryButton.Text = "新增類別";
            this._addCategoryButton.UseVisualStyleBackColor = true;
            // 
            // _categoryListBox
            // 
            this._categoryListBox.FormattingEnabled = true;
            this._categoryListBox.ItemHeight = 12;
            this._categoryListBox.Location = new System.Drawing.Point(0, 0);
            this._categoryListBox.Name = "_categoryListBox";
            this._categoryListBox.Size = new System.Drawing.Size(236, 436);
            this._categoryListBox.TabIndex = 2;
            // 
            // ProductManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 578);
            this.Controls.Add(this._managementTabControl);
            this.Controls.Add(this._title);
            this.Name = "ProductManageForm";
            this.Text = "ProductManagement";
            this._managementTabControl.ResumeLayout(false);
            this._productTabPage.ResumeLayout(false);
            this._editGroupBox.ResumeLayout(false);
            this._editGroupBox.PerformLayout();
            this._categoryTabPage.ResumeLayout(false);
            this._categoryGroupBox.ResumeLayout(false);
            this._categoryGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _title;
        private System.Windows.Forms.TabControl _managementTabControl;
        private System.Windows.Forms.TabPage _productTabPage;
        private System.Windows.Forms.GroupBox _editGroupBox;
        private System.Windows.Forms.Label _descriptionLabel;
        private System.Windows.Forms.Label _imagePathLabel;
        private System.Windows.Forms.Label _categoryLabel;
        private System.Windows.Forms.Label _moneyLabel;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.Label _productNameLabel;
        private System.Windows.Forms.Button _addProductButton;
        private System.Windows.Forms.ListBox _productListBox;
        private System.Windows.Forms.TabPage _categoryTabPage;
        private System.Windows.Forms.Button _browseButton;
        private System.Windows.Forms.ComboBox _categoryComboBox;
        private System.Windows.Forms.Button _modifyProductButton;
        private System.Windows.Forms.TextBox _descriptionTextBox;
        private System.Windows.Forms.TextBox _imagePathTextBox;
        private System.Windows.Forms.TextBox _priceTextBox;
        private System.Windows.Forms.TextBox _productNameTextBox;
        private System.Windows.Forms.GroupBox _categoryGroupBox;
        private System.Windows.Forms.Button _modifyCategoryButton;
        private System.Windows.Forms.TextBox _productsTextBox;
        private System.Windows.Forms.TextBox _categoryNameTextBox;
        private System.Windows.Forms.Label _productsLabel;
        private System.Windows.Forms.Label _categoryNameLabel;
        private System.Windows.Forms.Button _addCategoryButton;
        private System.Windows.Forms.ListBox _categoryListBox;
    }
}