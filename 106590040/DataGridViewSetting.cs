using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _OrderApp
{
    public class DataGridViewSetting
    {
        const int TWO = 2;

        // 返回刪除鈕的大小位置
        public Rectangle GetDeleteRectangle(System.Drawing.Point location, System.Drawing.Point imageSize, System.Drawing.Point cellSize)
        {
            double factor = 0;
            if ((double)cellSize.X / imageSize.X < (double)cellSize.Y / imageSize.Y)
            {
                factor = (double)cellSize.X / imageSize.X;
            }
            else
            {
                factor = (double)cellSize.Y / imageSize.Y;
            }
            int width = Convert.ToInt32(imageSize.X * factor);
            int height = Convert.ToInt32(imageSize.Y * factor);
            int left = location.X + (cellSize.X - width) / TWO;
            int top = location.Y + (cellSize.Y - height) / TWO;
            return new Rectangle(left, top, width, height);
        }
    }
}
