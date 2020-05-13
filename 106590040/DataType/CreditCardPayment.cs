using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class CreditCardPayment
    {
        const int CARD_NUMBERS = 4;
        private Name _name;
        private string[] _cardNumber;
        private Date _availableDate;
        private string _email;
        private string _address;

        public CreditCardPayment()
        {
            _name = new Name();
            _cardNumber = new string[CARD_NUMBERS] { "", "", "", "" };
            _availableDate = new Date();
            _email = "";
            _address = "";
        }

        // surname的setter & getter
        public string FirstName
        {
            set
            {
                _name.FirstName = value;
            }
            get
            {
                return _name.FirstName;
            }
        }

        // forename的setter & getter
        public string LastName
        {
            set
            {
                _name.LastName = value;
            }
            get
            {
                return _name.LastName;
            }
        }

        // card number的setter & getter
        public string[] CardNumber
        {
            set
            {
                _cardNumber = value;
            }
            get
            {
                return _cardNumber;
            }
        }

        // available year的setter & getter
        public int Year
        {
            set
            {
                _availableDate.Year = value;
            }
            get
            {
                return _availableDate.Year;
            }
        }

        // available month的setter & getter
        public int Month
        {
            set
            {
                _availableDate.Month = value;
            }
            get
            {
                return _availableDate.Month;
            }
        }

        // email的setter & getter
        public string Email
        {
            set
            {
                _email = value;
            }
            get
            {
                return _email;
            }
        }

        // address的setter & getter
        public string Address
        {
            set
            {
                _address = value;
            }
            get
            {
                return _address;
            }
        }

        // 判斷CreditCardPayment是否相等
        public bool IsEqual(CreditCardPayment creditCardPayment)
        {
            return FirstName == creditCardPayment.FirstName &&
                LastName == creditCardPayment.LastName &&
                IsCardNumberEqual(creditCardPayment.CardNumber) &&
                Year == creditCardPayment.Year &&
                Month == creditCardPayment.Month &&
                _email == creditCardPayment.Email &&
                _address == creditCardPayment.Address;
        }

        // 判斷card number是否相等
        private bool IsCardNumberEqual(string[] cardNumber)
        {
            for (int count = 0; count < CARD_NUMBERS; count++)
            {
                if (_cardNumber[count] != cardNumber[count])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
