namespace _OrderApp
{
    partial class CreditCardPaymentForm
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
            this.components = new System.ComponentModel.Container();
            this._titleLabel = new System.Windows.Forms.Label();
            this._nameLabel = new System.Windows.Forms.Label();
            this._cardNumberLabel = new System.Windows.Forms.Label();
            this._availableDateLabel = new System.Windows.Forms.Label();
            this._lastNumberLabel = new System.Windows.Forms.Label();
            this._emailLabel = new System.Windows.Forms.Label();
            this._addressLabel = new System.Windows.Forms.Label();
            this._firstNameTextBox = new System.Windows.Forms.TextBox();
            this._lastNameTextBox = new System.Windows.Forms.TextBox();
            this._secondCardNumberTextBox = new System.Windows.Forms.TextBox();
            this._firstCardNumberTextBox = new System.Windows.Forms.TextBox();
            this._fourthCardNumberTextBox = new System.Windows.Forms.TextBox();
            this._thirdCardNumberTextBox = new System.Windows.Forms.TextBox();
            this._monthComboBox = new System.Windows.Forms.ComboBox();
            this._yearComboBox = new System.Windows.Forms.ComboBox();
            this._lastNumberTextBox = new System.Windows.Forms.TextBox();
            this._emailTextBox = new System.Windows.Forms.TextBox();
            this._addressTextBox = new System.Windows.Forms.TextBox();
            this._confirmButton = new System.Windows.Forms.Button();
            this._nameDashLabel = new System.Windows.Forms.Label();
            this._firstCardDashLabel = new System.Windows.Forms.Label();
            this._secondCardDashLabel = new System.Windows.Forms.Label();
            this._thirdCardDashLabel = new System.Windows.Forms.Label();
            this._dateSeparateLabel = new System.Windows.Forms.Label();
            this._formatErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._formatErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _titleLabel
            // 
            this._titleLabel.AutoSize = true;
            this._titleLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._titleLabel.Location = new System.Drawing.Point(140, 18);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(117, 26);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "信用卡支付";
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(12, 49);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(71, 12);
            this._nameLabel.TabIndex = 1;
            this._nameLabel.Text = "持卡人姓名*";
            // 
            // _cardNumberLabel
            // 
            this._cardNumberLabel.AutoSize = true;
            this._cardNumberLabel.Location = new System.Drawing.Point(12, 89);
            this._cardNumberLabel.Name = "_cardNumberLabel";
            this._cardNumberLabel.Size = new System.Drawing.Size(71, 12);
            this._cardNumberLabel.TabIndex = 2;
            this._cardNumberLabel.Text = "信用卡卡號*";
            // 
            // _availableDateLabel
            // 
            this._availableDateLabel.AutoSize = true;
            this._availableDateLabel.Location = new System.Drawing.Point(12, 129);
            this._availableDateLabel.Name = "_availableDateLabel";
            this._availableDateLabel.Size = new System.Drawing.Size(94, 12);
            this._availableDateLabel.TabIndex = 3;
            this._availableDateLabel.Text = "有效日期*(月/年)";
            // 
            // _lastNumberLabel
            // 
            this._lastNumberLabel.AutoSize = true;
            this._lastNumberLabel.Location = new System.Drawing.Point(12, 167);
            this._lastNumberLabel.Name = "_lastNumberLabel";
            this._lastNumberLabel.Size = new System.Drawing.Size(71, 12);
            this._lastNumberLabel.TabIndex = 4;
            this._lastNumberLabel.Text = "背面末三碼*";
            // 
            // _emailLabel
            // 
            this._emailLabel.AutoSize = true;
            this._emailLabel.Location = new System.Drawing.Point(10, 207);
            this._emailLabel.Name = "_emailLabel";
            this._emailLabel.Size = new System.Drawing.Size(38, 12);
            this._emailLabel.TabIndex = 5;
            this._emailLabel.Text = "Email*";
            // 
            // _addressLabel
            // 
            this._addressLabel.AutoSize = true;
            this._addressLabel.Location = new System.Drawing.Point(12, 247);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(59, 12);
            this._addressLabel.TabIndex = 6;
            this._addressLabel.Text = "帳單地址*";
            // 
            // _firstNameTextBox
            // 
            this._firstNameTextBox.Location = new System.Drawing.Point(12, 64);
            this._firstNameTextBox.Name = "_firstNameTextBox";
            this._firstNameTextBox.Size = new System.Drawing.Size(175, 22);
            this._firstNameTextBox.TabIndex = 7;
            // 
            // _lastNameTextBox
            // 
            this._lastNameTextBox.Location = new System.Drawing.Point(210, 64);
            this._lastNameTextBox.Name = "_lastNameTextBox";
            this._lastNameTextBox.Size = new System.Drawing.Size(175, 22);
            this._lastNameTextBox.TabIndex = 8;
            // 
            // _secondCardNumberTextBox
            // 
            this._secondCardNumberTextBox.Location = new System.Drawing.Point(112, 104);
            this._secondCardNumberTextBox.Name = "_secondCardNumberTextBox";
            this._secondCardNumberTextBox.Size = new System.Drawing.Size(75, 22);
            this._secondCardNumberTextBox.TabIndex = 10;
            // 
            // _firstCardNumberTextBox
            // 
            this._firstCardNumberTextBox.Location = new System.Drawing.Point(12, 104);
            this._firstCardNumberTextBox.Name = "_firstCardNumberTextBox";
            this._firstCardNumberTextBox.Size = new System.Drawing.Size(75, 22);
            this._firstCardNumberTextBox.TabIndex = 9;
            // 
            // _fourthCardNumberTextBox
            // 
            this._fourthCardNumberTextBox.Location = new System.Drawing.Point(310, 104);
            this._fourthCardNumberTextBox.Name = "_fourthCardNumberTextBox";
            this._fourthCardNumberTextBox.Size = new System.Drawing.Size(75, 22);
            this._fourthCardNumberTextBox.TabIndex = 12;
            // 
            // _thirdCardNumberTextBox
            // 
            this._thirdCardNumberTextBox.Location = new System.Drawing.Point(210, 104);
            this._thirdCardNumberTextBox.Name = "_thirdCardNumberTextBox";
            this._thirdCardNumberTextBox.Size = new System.Drawing.Size(75, 22);
            this._thirdCardNumberTextBox.TabIndex = 11;
            // 
            // _monthComboBox
            // 
            this._monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._monthComboBox.FormattingEnabled = true;
            this._monthComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this._monthComboBox.Location = new System.Drawing.Point(12, 144);
            this._monthComboBox.Name = "_monthComboBox";
            this._monthComboBox.Size = new System.Drawing.Size(175, 20);
            this._monthComboBox.TabIndex = 13;
            // 
            // _yearComboBox
            // 
            this._yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._yearComboBox.FormattingEnabled = true;
            this._yearComboBox.Items.AddRange(new object[] {
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028"});
            this._yearComboBox.Location = new System.Drawing.Point(210, 144);
            this._yearComboBox.Name = "_yearComboBox";
            this._yearComboBox.Size = new System.Drawing.Size(175, 20);
            this._yearComboBox.TabIndex = 14;
            // 
            // _lastNumberTextBox
            // 
            this._lastNumberTextBox.Location = new System.Drawing.Point(12, 182);
            this._lastNumberTextBox.Name = "_lastNumberTextBox";
            this._lastNumberTextBox.Size = new System.Drawing.Size(373, 22);
            this._lastNumberTextBox.TabIndex = 15;
            // 
            // _emailTextBox
            // 
            this._emailTextBox.Location = new System.Drawing.Point(12, 222);
            this._emailTextBox.Name = "_emailTextBox";
            this._emailTextBox.Size = new System.Drawing.Size(373, 22);
            this._emailTextBox.TabIndex = 16;
            // 
            // _addressTextBox
            // 
            this._addressTextBox.Location = new System.Drawing.Point(12, 262);
            this._addressTextBox.Name = "_addressTextBox";
            this._addressTextBox.Size = new System.Drawing.Size(373, 22);
            this._addressTextBox.TabIndex = 17;
            // 
            // _confirmButton
            // 
            this._confirmButton.BackColor = System.Drawing.Color.Red;
            this._confirmButton.Enabled = false;
            this._confirmButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._confirmButton.Location = new System.Drawing.Point(12, 324);
            this._confirmButton.Name = "_confirmButton";
            this._confirmButton.Size = new System.Drawing.Size(373, 28);
            this._confirmButton.TabIndex = 18;
            this._confirmButton.Text = "確認";
            this._confirmButton.UseVisualStyleBackColor = false;
            // 
            // _nameDashLabel
            // 
            this._nameDashLabel.AutoSize = true;
            this._nameDashLabel.Location = new System.Drawing.Point(194, 67);
            this._nameDashLabel.Name = "_nameDashLabel";
            this._nameDashLabel.Size = new System.Drawing.Size(9, 12);
            this._nameDashLabel.TabIndex = 19;
            this._nameDashLabel.Text = "-";
            // 
            // _firstCardDashLabel
            // 
            this._firstCardDashLabel.AutoSize = true;
            this._firstCardDashLabel.Location = new System.Drawing.Point(95, 107);
            this._firstCardDashLabel.Name = "_firstCardDashLabel";
            this._firstCardDashLabel.Size = new System.Drawing.Size(9, 12);
            this._firstCardDashLabel.TabIndex = 20;
            this._firstCardDashLabel.Text = "-";
            // 
            // _secondCardDashLabel
            // 
            this._secondCardDashLabel.AutoSize = true;
            this._secondCardDashLabel.Location = new System.Drawing.Point(194, 107);
            this._secondCardDashLabel.Name = "_secondCardDashLabel";
            this._secondCardDashLabel.Size = new System.Drawing.Size(9, 12);
            this._secondCardDashLabel.TabIndex = 21;
            this._secondCardDashLabel.Text = "-";
            // 
            // _thirdCardDashLabel
            // 
            this._thirdCardDashLabel.AutoSize = true;
            this._thirdCardDashLabel.Location = new System.Drawing.Point(293, 107);
            this._thirdCardDashLabel.Name = "_thirdCardDashLabel";
            this._thirdCardDashLabel.Size = new System.Drawing.Size(9, 12);
            this._thirdCardDashLabel.TabIndex = 22;
            this._thirdCardDashLabel.Text = "-";
            // 
            // _dateSeparateLabel
            // 
            this._dateSeparateLabel.AutoSize = true;
            this._dateSeparateLabel.Location = new System.Drawing.Point(194, 147);
            this._dateSeparateLabel.Name = "_dateSeparateLabel";
            this._dateSeparateLabel.Size = new System.Drawing.Size(8, 12);
            this._dateSeparateLabel.TabIndex = 23;
            this._dateSeparateLabel.Text = "/";
            // 
            // _formatErrorProvider
            // 
            this._formatErrorProvider.ContainerControl = this;
            // 
            // CreditCardPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 368);
            this.Controls.Add(this._dateSeparateLabel);
            this.Controls.Add(this._thirdCardDashLabel);
            this.Controls.Add(this._secondCardDashLabel);
            this.Controls.Add(this._firstCardDashLabel);
            this.Controls.Add(this._nameDashLabel);
            this.Controls.Add(this._confirmButton);
            this.Controls.Add(this._addressTextBox);
            this.Controls.Add(this._emailTextBox);
            this.Controls.Add(this._lastNumberTextBox);
            this.Controls.Add(this._yearComboBox);
            this.Controls.Add(this._monthComboBox);
            this.Controls.Add(this._fourthCardNumberTextBox);
            this.Controls.Add(this._thirdCardNumberTextBox);
            this.Controls.Add(this._secondCardNumberTextBox);
            this.Controls.Add(this._firstCardNumberTextBox);
            this.Controls.Add(this._lastNameTextBox);
            this.Controls.Add(this._firstNameTextBox);
            this.Controls.Add(this._addressLabel);
            this.Controls.Add(this._emailLabel);
            this.Controls.Add(this._lastNumberLabel);
            this.Controls.Add(this._availableDateLabel);
            this.Controls.Add(this._cardNumberLabel);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._titleLabel);
            this.Name = "CreditCardPaymentForm";
            this.Text = "CreditCardPayment";
            ((System.ComponentModel.ISupportInitialize)(this._formatErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label _cardNumberLabel;
        private System.Windows.Forms.Label _availableDateLabel;
        private System.Windows.Forms.Label _lastNumberLabel;
        private System.Windows.Forms.Label _emailLabel;
        private System.Windows.Forms.Label _addressLabel;
        private System.Windows.Forms.TextBox _firstNameTextBox;
        private System.Windows.Forms.TextBox _lastNameTextBox;
        private System.Windows.Forms.TextBox _secondCardNumberTextBox;
        private System.Windows.Forms.TextBox _firstCardNumberTextBox;
        private System.Windows.Forms.TextBox _fourthCardNumberTextBox;
        private System.Windows.Forms.TextBox _thirdCardNumberTextBox;
        private System.Windows.Forms.ComboBox _monthComboBox;
        private System.Windows.Forms.ComboBox _yearComboBox;
        private System.Windows.Forms.TextBox _lastNumberTextBox;
        private System.Windows.Forms.TextBox _emailTextBox;
        private System.Windows.Forms.TextBox _addressTextBox;
        private System.Windows.Forms.Button _confirmButton;
        private System.Windows.Forms.Label _nameDashLabel;
        private System.Windows.Forms.Label _firstCardDashLabel;
        private System.Windows.Forms.Label _secondCardDashLabel;
        private System.Windows.Forms.Label _thirdCardDashLabel;
        private System.Windows.Forms.Label _dateSeparateLabel;
        private System.Windows.Forms.ErrorProvider _formatErrorProvider;
    }
}