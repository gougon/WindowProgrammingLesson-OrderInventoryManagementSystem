using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class Position
    {
        private int _x;
        private int _y;

        // position的constructor
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // x的getter & setter
        public int X
        {
            set
            {
                _x = value;
            }
            get
            {
                return _x;
            }
        }

        // y的getter & setter
        public int Y
        {
            set
            {
                _y = value;
            }
            get
            {
                return _y;
            }
        }
    }
}
