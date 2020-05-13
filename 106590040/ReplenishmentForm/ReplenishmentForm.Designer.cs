namespace _OrderApp
{
    partial class ReplenishmentForm
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
            this._nameLabel = new System.Windows.Forms.Label();
            this._categoryLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._stockAmountLabel = new System.Windows.Forms.Label();
            this._replenishmentLabel = new System.Windows.Forms.Label();
            this._confirmButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._replenishmentTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _titleLabel
            // 
            this._titleLabel.AutoSize = true;
            this._titleLabel.Font = new System.Drawing.Font("微軟正黑體", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._titleLabel.Location = new System.Drawing.Point(213, 24);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(153, 55);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "補貨單";
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._nameLabel.Location = new System.Drawing.Point(41, 107);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(133, 35);
            this._nameLabel.TabIndex = 1;
            this._nameLabel.Text = "商品名稱:";
            // 
            // _categoryLabel
            // 
            this._categoryLabel.AutoSize = true;
            this._categoryLabel.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._categoryLabel.Location = new System.Drawing.Point(41, 165);
            this._categoryLabel.Name = "_categoryLabel";
            this._categoryLabel.Size = new System.Drawing.Size(133, 35);
            this._categoryLabel.TabIndex = 2;
            this._categoryLabel.Text = "商品類別:";
            // 
            // _priceLabel
            // 
            this._priceLabel.AutoSize = true;
            this._priceLabel.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._priceLabel.Location = new System.Drawing.Point(41, 222);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(133, 35);
            this._priceLabel.TabIndex = 3;
            this._priceLabel.Text = "商品單價:";
            // 
            // _stockAmountLabel
            // 
            this._stockAmountLabel.AutoSize = true;
            this._stockAmountLabel.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._stockAmountLabel.Location = new System.Drawing.Point(41, 276);
            this._stockAmountLabel.Name = "_stockAmountLabel";
            this._stockAmountLabel.Size = new System.Drawing.Size(133, 35);
            this._stockAmountLabel.TabIndex = 4;
            this._stockAmountLabel.Text = "庫存數量:";
            // 
            // _replenishmentLabel
            // 
            this._replenishmentLabel.AutoSize = true;
            this._replenishmentLabel.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._replenishmentLabel.Location = new System.Drawing.Point(41, 333);
            this._replenishmentLabel.Name = "_replenishmentLabel";
            this._replenishmentLabel.Size = new System.Drawing.Size(133, 35);
            this._replenishmentLabel.TabIndex = 5;
            this._replenishmentLabel.Text = "補貨數量:";
            // 
            // _confirmButton
            // 
            this._confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this._confirmButton.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._confirmButton.Location = new System.Drawing.Point(47, 424);
            this._confirmButton.Name = "_confirmButton";
            this._confirmButton.Size = new System.Drawing.Size(192, 56);
            this._confirmButton.TabIndex = 6;
            this._confirmButton.Text = "確認";
            this._confirmButton.UseVisualStyleBackColor = false;
            // 
            // _cancelButton
            // 
            this._cancelButton.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._cancelButton.Location = new System.Drawing.Point(349, 424);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(192, 56);
            this._cancelButton.TabIndex = 7;
            this._cancelButton.Text = "取消";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _replenishmentTextBox
            // 
            this._replenishmentTextBox.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._replenishmentTextBox.Location = new System.Drawing.Point(180, 333);
            this._replenishmentTextBox.Name = "_replenishmentTextBox";
            this._replenishmentTextBox.Size = new System.Drawing.Size(59, 35);
            this._replenishmentTextBox.TabIndex = 8;
            // 
            // ReplenishmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 503);
            this.Controls.Add(this._replenishmentTextBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._confirmButton);
            this.Controls.Add(this._replenishmentLabel);
            this.Controls.Add(this._stockAmountLabel);
            this.Controls.Add(this._priceLabel);
            this.Controls.Add(this._categoryLabel);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._titleLabel);
            this.Name = "ReplenishmentForm";
            this.Text = "補貨單";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label _categoryLabel;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.Label _stockAmountLabel;
        private System.Windows.Forms.Label _replenishmentLabel;
        private System.Windows.Forms.Button _confirmButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.TextBox _replenishmentTextBox;
    }
}