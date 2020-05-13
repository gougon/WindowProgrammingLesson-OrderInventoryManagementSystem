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
    public partial class CreditCardPaymentForm : Form
    {
        OrderModel _model;
        CreditCardPaymentPresentationModel _presentationModel;

        // CreditCardPaymentForm的constructor
        public CreditCardPaymentForm(CreditCardPaymentPresentationModel presentationModel, OrderModel model)
        {
            InitializeComponent();
            _model = model;
            _presentationModel = presentationModel;
            Initialize();
            GiveEvents();
        }

        // confirm button的click事件
        private void ClickConfirmButton(object sender, EventArgs e)
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment();
            _model.Order.FirstName = _firstNameTextBox.Text;
            _model.Order.LastName = _lastNameTextBox.Text;
            _model.Order.CardNumber = new string[] { _firstCardNumberTextBox.Text, _secondCardNumberTextBox.Text, _thirdCardNumberTextBox.Text, _fourthCardNumberTextBox.Text };
            _model.Order.Month = _monthComboBox.SelectedIndex;
            _model.Order.Year = _yearComboBox.SelectedIndex;
            _model.Order.Email = _emailTextBox.Text;
            _model.Order.Address = _addressTextBox.Text;
            _model.TradeOrder();
            _model.DeleteOrder();
            DialogResult result = MessageBox.Show("訂購完成");
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        // 將name設成只能輸入字串
        private void PressKeyInNameTextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = !_presentationModel.IsCharacterString(e.KeyChar);
        }

        // 將card number設成只能輸入4位數字
        private void PressKeyInCardNumberTextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = !_presentationModel.IsFourPlaceNumber(((TextBox)sender).TextLength, e.KeyChar);
        }

        // 將last number設成只能輸入3位數字
        private void PressKeyInLastNumberTextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = !_presentationModel.IsThreePlaceNumber(((TextBox)sender).TextLength, e.KeyChar);
        }

        // surname的驗證
        private void ConfirmFirstNameTextBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_firstNameTextBox, _presentationModel.ConfirmFirstName(((TextBox)sender).Text));
        }

        // forename的驗證
        private void ConfirmLastNameTextBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_lastNameTextBox, _presentationModel.ConfirmLastName(((TextBox)sender).Text));
        }

        // first card number的驗證
        private void ConfirmFirstCardNumberTextBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_firstCardNumberTextBox, _presentationModel.ConfirmFirstCardNumber(((TextBox)sender).Text));
        }

        // second card number的驗證
        private void ConfirmSecondCardNumberTextBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_secondCardNumberTextBox, _presentationModel.ConfirmSecondCardNumber(((TextBox)sender).Text));
        }

        // third card number的驗證
        private void ConfirmThirdCardNumberTextBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_thirdCardNumberTextBox, _presentationModel.ConfirmThirdCardNumber(((TextBox)sender).Text));
        }

        // fourth card number的驗證
        private void ConfirmFourthCardNumberTextBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_fourthCardNumberTextBox, _presentationModel.ConfirmFourthCardNumber(((TextBox)sender).Text));
        }

        // month的驗證
        private void ConfirmMonthComboBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_monthComboBox, _presentationModel.ConfirmMonth(((ComboBox)sender).SelectedIndex));
        }

        // year的驗證
        private void ConfirmYearComboBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_yearComboBox, _presentationModel.ConfirmYear(((ComboBox)sender).SelectedIndex));
        }

        // 末三碼的驗證
        private void ConfirmLastNumberTextBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_lastNumberTextBox, _presentationModel.ConfirmLastNumber(((TextBox)sender).Text));
        }

        // email的驗證
        private void ConfirmEmailTextBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_emailTextBox, _presentationModel.ConfirmEmail(((TextBox)sender).Text));
        }

        // address的驗證
        private void ConfirmAddressTextBox(object sender, EventArgs e)
        {
            _formatErrorProvider.SetError(_addressTextBox, _presentationModel.ConfirmAddress(((TextBox)sender).Text));
        }

        // 視窗關閉事件
        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            _model._modelChanged -= RefreshControls;
        }

        // 給予UI事件
        private void GiveEvents()
        {
            GiveObserverEvents();
            GiveButtonEvents();
            GiveKeyPressEvents();
            GiveConfirmEvents();
        }

        // 給予obsever的事件
        private void GiveObserverEvents()
        {
            FormClosing += CloseForm;
            _presentationModel._presentationModelChanged += RefreshControls;
        }

        // 給予button的事件
        private void GiveButtonEvents()
        {
            _confirmButton.Click += ClickConfirmButton;
        }

        // 給予key press的事件
        private void GiveKeyPressEvents()
        {
            _firstNameTextBox.KeyPress += PressKeyInNameTextBox;
            _lastNameTextBox.KeyPress += PressKeyInNameTextBox;
            _firstCardNumberTextBox.KeyPress += PressKeyInCardNumberTextBox;
            _secondCardNumberTextBox.KeyPress += PressKeyInCardNumberTextBox;
            _thirdCardNumberTextBox.KeyPress += PressKeyInCardNumberTextBox;
            _fourthCardNumberTextBox.KeyPress += PressKeyInCardNumberTextBox;
            _lastNumberTextBox.KeyPress += PressKeyInLastNumberTextBox;
        }

        // 給予Confirm的事件
        private void GiveConfirmEvents()
        {
            _firstNameTextBox.Validating += ConfirmFirstNameTextBox;
            _lastNameTextBox.Validating += ConfirmLastNameTextBox;
            _firstCardNumberTextBox.Validating += ConfirmFirstCardNumberTextBox;
            _secondCardNumberTextBox.Validating += ConfirmSecondCardNumberTextBox;
            _thirdCardNumberTextBox.Validating += ConfirmThirdCardNumberTextBox;
            _fourthCardNumberTextBox.Validating += ConfirmFourthCardNumberTextBox;
            _monthComboBox.Validating += ConfirmMonthComboBox;
            _yearComboBox.Validating += ConfirmYearComboBox;
            _lastNumberTextBox.Validating += ConfirmLastNumberTextBox;
            _emailTextBox.Validating += ConfirmEmailTextBox;
            _addressTextBox.Validating += ConfirmAddressTextBox;
        }

        // 初始化
        private void Initialize()
        {
            FillInData();
            ConfirmData();
        }

        // 放入order的資料
        private void FillInData()
        {
            _firstNameTextBox.Text = _model.Order.FirstName;
            _lastNameTextBox.Text = _model.Order.LastName;
            _firstCardNumberTextBox.Text = _model.Order.CardNumber[0];
            _secondCardNumberTextBox.Text = _model.Order.CardNumber[1];
            _thirdCardNumberTextBox.Text = _model.Order.CardNumber[2];
            _fourthCardNumberTextBox.Text = _model.Order.CardNumber[3];
            _monthComboBox.SelectedIndex = _model.Order.Month;
            _yearComboBox.SelectedIndex = _model.Order.Year;
            _emailTextBox.Text = _model.Order.Email;
            _addressTextBox.Text = _model.Order.Address;
        }

        // 驗證資料
        private void ConfirmData()
        {
            _presentationModel.ConfirmFirstName(_firstNameTextBox.Text);
            _presentationModel.ConfirmLastName(_lastNameTextBox.Text);
            _presentationModel.ConfirmFirstCardNumber(_firstCardNumberTextBox.Text);
            _presentationModel.ConfirmSecondCardNumber(_secondCardNumberTextBox.Text);
            _presentationModel.ConfirmThirdCardNumber(_thirdCardNumberTextBox.Text);
            _presentationModel.ConfirmFourthCardNumber(_fourthCardNumberTextBox.Text);
            _presentationModel.ConfirmMonth(_monthComboBox.SelectedIndex);
            _presentationModel.ConfirmYear(_yearComboBox.SelectedIndex);
            _presentationModel.ConfirmEmail(_emailTextBox.Text);
            _presentationModel.ConfirmAddress(_addressTextBox.Text);
        }

        // 刷新controls
        private void RefreshControls()
        {
            _confirmButton.Enabled = _presentationModel.IsConfirmButtonEnable;
        }
    }
}
