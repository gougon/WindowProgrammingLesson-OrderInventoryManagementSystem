using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class Date
    {
        private int _year;
        private int _month;
        private int _day;

        // date的constructor
        public Date()
        {
            _year = -1;
            _month = -1;
            _day = -1;
        }

        // date的constructor
        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        // year的setter & getter
        public int Year
        {
            set
            {
                _year = value;
            }
            get
            {
                return _year;
            }
        }

        // month的setter & getter
        public int Month
        {
            set
            {
                _month = value;
            }
            get
            {
                return _month;
            }
        }

        // year的setter & getter
        public int Day
        {
            set
            {
                _day = value;
            }
            get
            {
                return _day;
            }
        }
    }
}
