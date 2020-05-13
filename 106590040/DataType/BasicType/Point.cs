using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class Point
    {
        const string EXCEPTION_TEXT = "The class \"Point\" must be positive.";
        private int _category;
        private int _index;

        public Point()
        {
            Category = 0;
            Index = 0;
        }

        public Point(int category, int index)
        {
            if (category < 0 || index < 0)
            {
                throw new ArgumentException(EXCEPTION_TEXT);
            }
            Category = category;
            Index = index;
        }

        public int Category
        {
            set
            {
                _category = value;
            }
            get
            {
                return _category;
            }
        }

        public int Index
        {
            set
            {
                _index = value;
            }
            get
            {
                return _index;
            }
        }

        // 判斷point是否相等
        public bool IsEqual(Point point)
        {
            return Category == point.Category &&
                Index == point.Index;
        }
    }
}
