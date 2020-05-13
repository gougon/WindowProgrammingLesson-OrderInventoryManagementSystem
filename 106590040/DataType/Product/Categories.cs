using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class Categories
    {
        // Init serial number
        // 0. MotherBoard
        // 1. CPU
        // 2. Memory
        // 3. HardDisk
        // 4. DisplayCard
        // 5. Computer
        public const int CATEGORY_COUNT = 6;
        const string CATEGORY_NAME_PATH = "../../../Product/productCategory.txt";
        const string MOTHER_BOARD_PRODUCT_PATH = "../../../Product/motherBoard.txt";
        const string CENTRAL_PROCESSING_UNIT_PRODUCT_PATH = "../../../Product/centralProcessingUnit.txt";
        const string MEMORY_PRODUCT_PATH = "../../../Product/memory.txt";
        const string HARD_DISK_PRODUCT_PATH = "../../../Product/hardDisk.txt";
        const string DISPLAY_CARD_PRODUCT_PATH = "../../../Product/displayCard.txt";
        const string COMPUTER_PRODUCT_PATH = "../../../Product/computer.txt";
        const string LOAD_EXCEPTION_TEXT = "Paths's count is different from CategoryNames's count";
        string[] _paths = { MOTHER_BOARD_PRODUCT_PATH, CENTRAL_PROCESSING_UNIT_PRODUCT_PATH, MEMORY_PRODUCT_PATH, HARD_DISK_PRODUCT_PATH, DISPLAY_CARD_PRODUCT_PATH, COMPUTER_PRODUCT_PATH };
        private Dictionary<int, string> _names = new Dictionary<int, string>();
        private List<Category> _categories = new List<Category>(); 

        public Categories()
        {
            LoadNames(CATEGORY_NAME_PATH);
            LoadCategories();
        }

        // 返回 category 數量
        public int Count
        {
            get
            {
                return _categories.Count;
            }
        }

        // 取得 category name
        public string GetCategoryName(int category)
        {
            return _names[category];
        }

        // 取得 product
        public Product GetProduct(Point categoryAndIndex)
        {
            return _categories[categoryAndIndex.Category].GetProduct(categoryAndIndex.Index);
        }

        // 取得 name
        public string GetName(Point categoryAndIndex)
        {
            return _categories[categoryAndIndex.Category].GetName(categoryAndIndex.Index);
        }

        // 取得 description
        public string GetDescription(Point categoryAndIndex)
        {
            return _categories[categoryAndIndex.Category].GetDescription(categoryAndIndex.Index);
        }

        // 取得產品介紹
        public string GetIntroduce(Point categoryAndIndex)
        {
            return _categories[categoryAndIndex.Category].GetName(categoryAndIndex.Index) + Environment.NewLine + _categories[categoryAndIndex.Category].GetDescription(categoryAndIndex.Index);
        }

        // 取得 imagePath
        public string GetImagePath(Point categoryAndIndex)
        {
            return _categories[categoryAndIndex.Category].GetImagePath(categoryAndIndex.Index);
        }

        // 取得 price
        public int GetPrice(Point categoryAndIndex)
        {
            return _categories[categoryAndIndex.Category].GetPrice(categoryAndIndex.Index);
        }

        // 取得 stock
        public int GetStock(Point categoryAndIndex)
        {
            return _categories[categoryAndIndex.Category].GetStock(categoryAndIndex.Index);
        }

        // 取得一種種類的商品數量
        public int GetProductQuantityOfCategory(int category)
        {
            return _categories[category].Count;
        }

        // 加入 category
        public void AddCategory(string name)
        {
            _names.Add(Count, name);
            _categories.Add(new Category(Count - 1, name));
        }

        // 新增 product
        public void AddProduct(int category, string name, ProductInfo info)
        {
            _categories[category].AddProduct(new Product(name, 0, info));
        }

        // 更改商品資訊
        public Product ModifyProduct(Point categoryAndIndex, int modifyCategory, string modifyName, ProductInfo info)
        {
            Product product = _categories[categoryAndIndex.Category].GetProduct(categoryAndIndex.Index);
            if (categoryAndIndex.Category == modifyCategory)
            {
                product = ModifyEqualCategoryProduct(categoryAndIndex, modifyName, info);
            }
            else
            {
                product = ModifyDifferentCategoryProduct(categoryAndIndex, modifyCategory, modifyName, info);
            }
            return product;
        }

        // 修改商品資訊
        private Product ModifyEqualCategoryProduct(Point categoryAndIndex, string modifyName, ProductInfo info)
        {
            Product product = _categories[categoryAndIndex.Category].GetProduct(categoryAndIndex.Index);
            product.Name = modifyName;
            product.Info = info;
            return product;
        }

        // remove & add category不同的商品
        private Product ModifyDifferentCategoryProduct(Point categoryAndIndex, int modifyCategory, string modifyName, ProductInfo info)
        {
            Product product = _categories[categoryAndIndex.Category].GetProduct(categoryAndIndex.Index);
            _categories[categoryAndIndex.Category].RemoveProductAt(categoryAndIndex.Index);
            _categories[modifyCategory].AddProduct(new Product(modifyName, product.StockAmount, info));
            return _categories[modifyCategory].LastProduct;
        }

        // 增加商品數量
        public void AddStock(Point categoryAndIndex, int amount)
        {
            _categories[categoryAndIndex.Category].GetProduct(categoryAndIndex.Index).StockAmount += amount;
        }

        // 透過 name 取得 category & index
        public Point GetCategoryAndIndexFromName(string name)
        {
            Point categoryAndIndex = new Point();
            for (int category = 0; category < _categories.Count; category++)
            {
                for (int index = 0; index < _categories[category].Count; index++)
                {
                    if (name == GetName(new Point(category, index)))
                    {
                        categoryAndIndex.Category = category;
                        categoryAndIndex.Index = index;
                        break;
                    }
                }
            }
            return categoryAndIndex;
        }

        // 讀入 categories
        private void LoadCategories()
        {
            for (int count = 0; count < _paths.Length; count++)
            {
                LoadCategoryProducts(_paths[count], count);
            }
        }

        // 讀入 products
        private void LoadCategoryProducts(string path, int category)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string name;
            while ((name = file.ReadLine()) != null)
            {
                ProductInfo productInfo = new ProductInfo();
                productInfo.ProductDescription = file.ReadLine();
                productInfo.ProductImagePath = file.ReadLine();
                productInfo.ProductPrice = int.Parse(file.ReadLine());
                int amount = int.Parse(file.ReadLine());
                _categories[category].AddProduct(new Product(name, amount, productInfo));
            }
        }

        // 讀入中文名稱
        private void LoadNames(string path)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(CATEGORY_NAME_PATH);
            for (int count = 0; count < CATEGORY_COUNT; count++)
            {
                AddCategory(file.ReadLine());
            }
            file.Close();
        }
    }
}
