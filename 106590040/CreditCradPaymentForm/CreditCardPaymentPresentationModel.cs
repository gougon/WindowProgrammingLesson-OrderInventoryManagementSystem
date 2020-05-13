using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class CreditCardPaymentPresentationModel
    {
        public delegate void PresentationModelChangedEventHandler();
        public event PresentationModelChangedEventHandler _presentationModelChanged;
        public const int FOUR = 4;
        public const int THREE = 3;
        const string NAME_ERROR_TEXT = "名稱必須輸入字串";
        const string CARD_NUMBER_ERROR_TEXT = "卡號必須是4位數字";
        const string DATE_ERROR_TEXT = "必須選擇日期";
        const string LAST_NUMBER_ERROR_TEXT = "末三碼必須是三位數字";
        const string EMAIL_ERROR_TEXT = "Email格式錯誤";
        const string ADDRESS_ERROR_TEXT = "必須輸入地址";
        const string CHINESE_EXPRESSION = "^[\u4e00-\u9fa5]$";
        const string EMAIL_EXPRESSION = @"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$";
        public const char DELETE = '\b';
        OrderModel _model;
        private bool _isFirstNameAvailable = false;
        private bool _isLastNameAvailable = false;
        private bool _isFirstCardNumberAvailable = false;
        private bool _isSecondCardNumberAvailable = false;
        private bool _isThirdCardNumberAvailable = false;
        private bool _isFourthCardNumberAvailable = false;
        private bool _isMonthAvailable = false;
        private bool _isYearAvailable = false;
        private bool _isLastNumberAvailable = false;
        private bool _isEmailAvailable = false;
        private bool _isAddressAvailable = false;

        // creditCardPaymentPresentationModel的constructor
        public CreditCardPaymentPresentationModel(OrderModel model)
        {
            _model = model;
        }

        // confirm button enable的getter
        public bool IsConfirmButtonEnable
        {
            get
            {
                return _isFirstNameAvailable && 
                    _isLastNameAvailable &&
                    _isFirstCardNumberAvailable && 
                    _isSecondCardNumberAvailable && 
                    _isThirdCardNumberAvailable &&
                    _isFourthCardNumberAvailable && 
                    _isMonthAvailable && 
                    _isYearAvailable &&
                    _isLastNumberAvailable &&
                    _isEmailAvailable &&
                    _isAddressAvailable;
            }
        }
       
        // 驗證並取得surname
        public string ConfirmFirstName(string firstName)
        {
            return ConfirmName(out _isFirstNameAvailable, firstName.Length);
        }

        // 驗證並取得forename
        public string ConfirmLastName(string lastName)
        {
            return ConfirmName(out _isLastNameAvailable, lastName.Length);
        }

        // 驗證並取得name的error text
        private string ConfirmName(out bool isNameAvailable, int length)
        {
            isNameAvailable = (length > 0);
            NotifyObserver();
            return GetNameErrorText(isNameAvailable);
        }

        // 取得name的error text
        private string GetNameErrorText(bool isNameAvailable)
        {
            if (isNameAvailable)
            {
                return null;
            }
            else
            {
                return NAME_ERROR_TEXT;
            }
        } 

        // 驗證並取得firstCardNumber
        public string ConfirmFirstCardNumber(string firstCardNumber)
        {
            return ConfirmCardNumber(out _isFirstCardNumberAvailable, firstCardNumber.Length);
        }

        // 驗證並取得secondCardNumber
        public string ConfirmSecondCardNumber(string secondCardNumber)
        {
            return ConfirmCardNumber(out _isSecondCardNumberAvailable, secondCardNumber.Length);
        }

        // 驗證並取得thirdCardNumber
        public string ConfirmThirdCardNumber(string thirdCardNumber)
        {
            return ConfirmCardNumber(out _isThirdCardNumberAvailable, thirdCardNumber.Length);
        }

        // 驗證並取得fourthCardNumber
        public string ConfirmFourthCardNumber(string fourthCardNumber)
        {
            return ConfirmCardNumber(out _isFourthCardNumberAvailable, fourthCardNumber.Length);
        }

        // 驗證並取得card number的error text
        private string ConfirmCardNumber(out bool isCardNumberAvailable, int length)
        {
            isCardNumberAvailable = (length == FOUR);
            NotifyObserver();
            return GetCardNumberErrorText(isCardNumberAvailable);
        }

        // 取得card number的error text
        private string GetCardNumberErrorText(bool isCardNumberAvailable)
        {
            if (isCardNumberAvailable)
            {
                return null;
            }
            else
            {
                return CARD_NUMBER_ERROR_TEXT;
            }
        }

        // 驗證並取得month
        public string ConfirmMonth(int selectedIndex)
        {
            return ConfirmDate(out _isMonthAvailable, selectedIndex);
        }

        // 驗證並取得year
        public string ConfirmYear(int selectedIndex)
        {
            return ConfirmDate(out _isYearAvailable, selectedIndex);
        }

        // 驗證並取得日期的error text
        private string ConfirmDate(out bool isDateAvailable, int selectedIndex)
        {
            isDateAvailable = (selectedIndex != -1);
            NotifyObserver();
            return GetDateErrorText(isDateAvailable);
        }

        // 取得日期的error text
        private string GetDateErrorText(bool isDateAvailable)
        {
            if (isDateAvailable)
            {
                return null;
            }
            else
            {
                return DATE_ERROR_TEXT;
            }
        }

        // 驗證並取得末三碼的error text
        public string ConfirmLastNumber(string lastNumber)
        {
            _isLastNumberAvailable = (lastNumber.Length == THREE);
            NotifyObserver();
            if (_isLastNumberAvailable)
            {
                return null;
            }
            else
            {
                return LAST_NUMBER_ERROR_TEXT;
            }
        }

        // 驗證並取得email的error text
        public string ConfirmEmail(string email)
        {
            _isEmailAvailable = IsEmail(email);
            NotifyObserver();
            if (_isEmailAvailable)
            {
                return null;
            }
            else
            {
                return EMAIL_ERROR_TEXT;
            }
        }

        // 驗證並取得address的error text
        public string ConfirmAddress(string address)
        {
            _isAddressAvailable = (address.Length > 0);
            NotifyObserver();
            if (_isAddressAvailable)
            {
                return null;
            }
            else
            {
                return ADDRESS_ERROR_TEXT;
            }
        }

        // 判斷是否為字串
        public bool IsCharacterString(char target)
        {
            Regex chinese = new Regex(CHINESE_EXPRESSION);
            return char.IsLetter(target) || chinese.IsMatch(target.ToString()) || target == DELETE;
        }

        // 判斷是否為4位數字
        public bool IsFourPlaceNumber(int place, char target)
        {
            return place < FOUR && char.IsDigit(target) || target == DELETE;
        }

        // 判斷是否為3位數字
        public bool IsThreePlaceNumber(int place, char target)
        {
            return place < THREE && char.IsDigit(target) || target == DELETE;
        }

        // 判斷是否為email
        private bool IsEmail(string target)
        {
            Regex email = new Regex(EMAIL_EXPRESSION);
            return email.IsMatch(target);
        }

        // 通知observer發生變化
        private void NotifyObserver()
        {
            if (_presentationModelChanged != null)
            {
                _presentationModelChanged();
            }
        }
    }
}
