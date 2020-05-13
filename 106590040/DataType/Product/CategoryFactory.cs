using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class CategoryFactory
    {
        public const int CATEGORY_COUNT = 6;
        const string CATEGORY_NAME_PATH = "../../../Product/productCategory.txt";
        private Dictionary<int, string> _categories = new Dictionary<int, string>();

        public CategoryFactory()
        {
            LoadNames(CATEGORY_NAME_PATH);
        }

        // 創造 category
        public Category CreateCategory()
        {
            return new Category(0, _categories[0]);
        }

        // 創造 category
        public Category CreateCategory(int serialNumber)
        {
            return new Category(serialNumber, _categories[serialNumber]);
        }

        // 加入 category
        public void AddCategory(string name)
        {
            _categories.Add(_categories.Count, name);
        }

        // 讀取 serialNumber 的 name
        public string GetName(int serialNumber)
        {
            return _categories[serialNumber];
        }

        // count property
        public int Count
        {
            get
            {
                return _categories.Count;
            }
        }

        // 讀入中文名稱
        private void LoadNames(string path)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(CATEGORY_NAME_PATH);
            for (int count = 0; count < CATEGORY_COUNT; count++)
            {
                _categories.Add(count, file.ReadLine());
            }
            file.Close();
        }
    }
}
