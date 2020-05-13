using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace _OrderApp
{
    public enum EditType
    {
        Modify = 0,
        Add = 1
    };

    public class ProductManagePresentationModel
    {
        public delegate void PresentationModelChangedEventHandler();
        public event PresentationModelChangedEventHandler _presentationModelChanged;
        public delegate void ListBoxChangedEventHandler();
        public event ListBoxChangedEventHandler _listBoxChanged;
        const string PARENT_PATH = "../../..";
        const string IMAGE_PATH = "/Image/";
        const char PATH = '\\';
        private OrderModel _model;
        private bool _isAddProductButtonEnable = true;
        private bool _isNameTextBoxAvailable = false;
        private bool _isPriceTextBoxAvailable = false;
        private bool _isPathTextBoxAvailable = false;
        private bool _isDescriptionTextBoxAvailable = false;
        private bool _isCategoryComboBoxAvailable = false;
        private bool _isNameTextBoxNull = true;
        private bool _isPriceTextBoxNull = true;
        private bool _isPathTextBoxNull = true;
        private bool _isDescriptionTextBoxNull = true;
        private bool _isCategoryComboBoxNull = true;
        private bool _isAddCategoryState = false;
        private bool _isModifyCategoryButtonEnable = false;
        EditType _editType = EditType.Modify;

        public ProductManagePresentationModel(OrderModel model)
        {
            _model = model;
        }

        // 將圖片路徑轉圜為沒帶有../../..的格式
        public string GetPathWithinParent(string name)
        {
            Point categoryAndIndex = _model.GetCategoryAndIndexFromName(name);
            string path = _model.GetImagePath(categoryAndIndex.Category, categoryAndIndex.Index);
            string[] noParentPath = Regex.Split(path, PARENT_PATH, RegexOptions.IgnoreCase);
            return noParentPath[noParentPath.Length - 1];
        }

        // 將圖片轉為帶有../../..的格式
        public string GetPathWithParent(string path)
        {
            return PARENT_PATH + path;
        }

        // 從絕對路徑轉換成相對路徑
        public string GetRelativePath(string basePath)
        {
            string productImageName = GetImageName(basePath);
            return IMAGE_PATH + productImageName;
        }

        // 取得圖片名稱
        private string GetImageName(string basePath)
        {
            string[] words = basePath.Split(PATH);
            return words[words.Length - 1];
        }

        // 對應按下add button的事件
        public void ClickAddProductButton()
        {
            _editType = EditType.Add;
            _isAddProductButtonEnable = false;
            NotifyObserver();
        }

        // 對應按下 add category button 的事件
        public void ClickAddCategoryButton()
        {
            _editType = EditType.Add;
            _isAddCategoryState = true;
            NotifyObserver();
        }

        // 取得 add button enable
        public bool IsAddProductButtonEnable
        {
            get
            {
                return _isAddProductButtonEnable;
            }
        }

        // 取得 add category state enable
        public bool IsAddCategoryState
        {
            get
            {
                return _isAddCategoryState;
            }
        }

        // 取得 modify category button enable
        public bool IsModifyCategoryButtonEnable
        {
            get
            {
                return _isModifyCategoryButtonEnable;
            }
        }

        // 取得editType
        public EditType EditType
        {
            set
            {
                _editType = value;
            }
            get
            {
                return _editType;
            }
        }

        // 設定null的bool值
        private void SetNull(bool flag)
        {
            _isNameTextBoxNull = flag;
            _isPriceTextBoxNull = flag;
            _isPathTextBoxNull = flag;
            _isDescriptionTextBoxNull = flag;
            _isCategoryComboBoxNull = flag;
        }

        // 對應按下save的事件
        public void ModifyProduct(string originName, int modifyCategory, string modifyName, ProductInfo info)
        {
            _model.ModifyProduct(originName, modifyCategory, modifyName, info);
            RefreshEnableState();
            NotifyObserver();
            NotifyListObserver();
        }

        // 對應按下add product的事件
        public void AddProduct(int category, string name, ProductInfo info)
        {
            _model.AddProduct(category, name, info);
            _editType = EditType.Modify;
            RefreshEnableState();
            NotifyObserver();
            NotifyListObserver();
        }

        // 對應按下 add category 的事件
        public void AddCategory(string name)
        {
            _model.AddCategory(name);
            _isAddCategoryState = false;
            _isModifyCategoryButtonEnable = false;
            NotifyObserver();
            NotifyListObserver();
        }

        // 刷新enable狀態
        private void RefreshEnableState()
        {
            _isAddProductButtonEnable = true;
            _isNameTextBoxAvailable = false;
            _isPriceTextBoxAvailable = false;
            _isPathTextBoxAvailable = false;
            _isDescriptionTextBoxAvailable = false;
            _isCategoryComboBoxAvailable = false;
        }

        // 對應select list box的事件
        public void SelectProductItem()
        {
            SetNull(false);
            NotifyObserver();
        }

        // 對應 select category list box 的事件
        public void SelectCategoryItem()
        {
            _isAddCategoryState = false;
            NotifyObserver();
        }

        // 對應 category name key up 的事件
        public void ConfirmCategoryName(string name)
        {
            if (_isAddCategoryState)
            {
                _isModifyCategoryButtonEnable = !string.Equals(name, "");
                NotifyObserver();
            }
        }

        // 對應name textbox key press的事件
        public void ConfirmName(string originName, string modifyName)
        {
            _isNameTextBoxNull = string.Equals(modifyName, "");
            _isNameTextBoxAvailable = !string.Equals(originName, modifyName);
            NotifyObserver();
        }

        // 對應price textbox key press的事件
        public void ConfirmPrice(string name, string modifyPrice)
        {
            Point categoryAndIndex = _model.GetCategoryAndIndexFromName(name);
            _isPriceTextBoxNull = string.Equals(modifyPrice, "");
            _isPriceTextBoxAvailable = (!_isPriceTextBoxNull && _model.GetProductPrice(categoryAndIndex.Category, categoryAndIndex.Index) != int.Parse(modifyPrice));
            NotifyObserver();
        }

        // 判斷price有沒有符合規則
        public bool PriceRule(char key)
        {
            return Char.IsDigit(key) || key == CreditCardPaymentPresentationModel.DELETE;
        }

        // 對應path textbox key press的事件
        public void ConfirmPath(string name, string modifyPath)
        {
            _isPathTextBoxNull = string.Equals(modifyPath, "");
            _isPathTextBoxAvailable = !string.Equals(GetPathWithinParent(name), modifyPath);
            NotifyObserver();
        }

        // 對應description textbox key press的事件
        public void ConfirmDescription(string name, string modifyDescription)
        {
            Point categoryAndIndex = _model.GetCategoryAndIndexFromName(name);
            _isDescriptionTextBoxNull = string.Equals(modifyDescription, "");
            _isDescriptionTextBoxAvailable = !string.Equals(_model.GetDescription(categoryAndIndex.Category, categoryAndIndex.Index), modifyDescription);
            NotifyObserver();
        }

        // 對應category combo box change的事件
        public void ConfirmCategory(string name, int modifyOrder)
        {
            _isCategoryComboBoxNull = modifyOrder < 0;
            _isCategoryComboBoxAvailable = (_model.GetCategoryAndIndexFromName(name).Category != modifyOrder);
            NotifyObserver();
        }

        // 驗證是否有修改產品資訊
        public bool IsModifyButtonEnable
        {
            get
            {
                if (_editType == EditType.Modify)
                {
                    return IsNotNull() && IsAvailable();
                }
                return IsNotNull();
            }
        }

        // 判斷是否 Available
        private bool IsAvailable()
        {
            return _isNameTextBoxAvailable || _isPriceTextBoxAvailable || _isPathTextBoxAvailable || _isDescriptionTextBoxAvailable || _isCategoryComboBoxAvailable;
        }

        // 判斷是否 NotNull
        private bool IsNotNull()
        {
            return !(_isNameTextBoxNull || _isPriceTextBoxNull || _isPathTextBoxNull || _isDescriptionTextBoxNull || _isCategoryComboBoxNull);
        }

        // 通知observer
        private void NotifyObserver()
        {
            if (_presentationModelChanged != null)
            {
                _presentationModelChanged();
            }
        }

        // 通知list變化
        private void NotifyListObserver()
        {
            if (_listBoxChanged != null)
            {
                _listBoxChanged();
            }
        }
    }
}
