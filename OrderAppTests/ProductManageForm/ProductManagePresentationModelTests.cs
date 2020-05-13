using Microsoft.VisualStudio.TestTools.UnitTesting;
using _OrderApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp.Tests
{
    [TestClass()]
    public class ProductManagePresentationModelTests
    {
        ProductManagePresentationModel _presentationModel;
        OrderModel _model;
        PrivateObject _target;
        bool _isModelNotify = false;
        bool _isListNotify = false;
        ProductInfo _info = new ProductInfo("desc", "../../../Image/path", 9999999);

        // Mock ModelNotify
        private void MockModelNotify()
        {
            _isModelNotify = true;
        }

        // Mock ListNotify
        private void MockListNotify()
        {
            _isListNotify = true;
        }

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _model = new OrderModel();
            _model.AddCategory("category");
            _model.AddProduct(6, "name", _info);
            _model.UpdateProductStock(6, 0, 15);
            _presentationModel = new ProductManagePresentationModel(_model);
            _presentationModel._presentationModelChanged += MockModelNotify;
            _presentationModel._listBoxChanged += MockListNotify;
            _target = new PrivateObject(_presentationModel);
            _isModelNotify = false;
            _isListNotify = false;
        }

        // 測試 GetPathWithinParent method
        [TestMethod()]
        public void GetPathWithinParentTest()
        {
            Assert.AreEqual(_presentationModel.GetPathWithinParent("name"), "/Image/path");
        }

        // 測試 GetPathWithParent method
        [TestMethod()]
        public void GetPathWithParentTest()
        {
            Assert.AreEqual(_presentationModel.GetPathWithParent("/Image/path"), "../../../Image/path");
        }

        // 測試 GetRelativePath method
        [TestMethod()]
        public void GetRelativePathTest()
        {
            Assert.AreEqual(_presentationModel.GetRelativePath("path"), "/Image/path");
        }

        // 測試 GetImageName method
        [TestMethod()]
        public void GetImageNameTest()
        {
            Assert.AreEqual(_target.Invoke("GetImageName", "E:\\Study\\視窗程式設計(MVC)\\hw5\\106590040\\106590040\\Image\\path"), "path");
        }

        // 測試 ClickAddProductButton method
        [TestMethod()]
        public void ClickAddProductButtonTest()
        {
            _presentationModel.ClickAddProductButton();
            Assert.AreEqual(_presentationModel.EditType, EditType.Add);
            Assert.AreEqual(_presentationModel.IsAddProductButtonEnable, false);
            Assert.AreEqual(_isModelNotify, true);
        }

        // 測試 IsAddButtonEnable method
        [TestMethod()]
        public void IsAddButtonEnableTest()
        {
            Assert.AreEqual(_presentationModel.IsAddProductButtonEnable, true);
        }

        // 測試 EditType method
        [TestMethod()]
        public void EditTypeTest()
        {
            Assert.AreEqual(_presentationModel.EditType, EditType.Modify);
            _presentationModel.EditType = EditType.Add;
            Assert.AreEqual(_presentationModel.EditType, EditType.Add);
        }

        // 測試 SetNull method
        [TestMethod()]
        public void SetNullTest()
        {
            _target.Invoke("SetNull", false);
            JudgeSetNullBeTriggerd(false);
            _target.Invoke("SetNull", true);
            JudgeSetNullBeTriggerd(true);
        }

        // 測試 ModifyProduct  method
        [TestMethod()]
        public void ModifyProductTest()
        {
            _presentationModel.ModifyProduct("name", 6, "modify name", _info);
            Assert.AreEqual(_model.GetName(6, 0), "modify name");
            JudgeRefreshEnableStateBeTriggerd();
            Assert.AreEqual(_isModelNotify, true);
            Assert.AreEqual(_isListNotify, true);
        }

        // 測試 AddProduct method
        [TestMethod()]
        public void AddProductTest()
        {
            _presentationModel.AddProduct(6, "add name", _info);
            Assert.AreEqual(_model.GetName(6, 1), "add name");
            JudgeRefreshEnableStateBeTriggerd();
            Assert.AreEqual(_isModelNotify, true);
            Assert.AreEqual(_isListNotify, true);
        }

        // 測試 RefreshEnableState method
        [TestMethod()]
        public void RefreshEnableStateTest()
        {
            JudgeRefreshEnableStateBeTriggerd();
        }

        // 測試 SelectProductItem method
        [TestMethod()]
        public void SelectProductItemTest()
        {
            _presentationModel.SelectProductItem();
            JudgeSetNullBeTriggerd(false);
            Assert.AreEqual(_isModelNotify, true);
        }

        // 測試 ConfirmName method
        [TestMethod()]
        public void ConfirmNameTest()
        {
            _presentationModel.ConfirmName("name", "modify name");
            Assert.AreEqual(_target.GetField("_isNameTextBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isNameTextBoxAvailable"), true);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmName("name", "name");
            Assert.AreEqual(_target.GetField("_isNameTextBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isNameTextBoxAvailable"), false);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmName("name", "");
            Assert.AreEqual(_target.GetField("_isNameTextBoxNull"), true);
        }

        // 測試 ConfirmPrice method
        [TestMethod()]
        public void ConfirmPriceTest()
        {
            _presentationModel.ConfirmPrice("name", "10");
            Assert.AreEqual(_target.GetField("_isPriceTextBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isPriceTextBoxAvailable"), true);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmPrice("name", "9999999");
            Assert.AreEqual(_target.GetField("_isPriceTextBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isPriceTextBoxAvailable"), false);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmPrice("name", "");
            Assert.AreEqual(_target.GetField("_isPriceTextBoxNull"), true);
        }

        // 測試  PriceRule method
        [TestMethod()]
        public void PriceRuleTest()
        {
            Assert.AreEqual(_presentationModel.PriceRule('1'), true);
            Assert.AreEqual(_presentationModel.PriceRule('0'), true);
            Assert.AreEqual(_presentationModel.PriceRule('a'), false);
            Assert.AreEqual(_presentationModel.PriceRule('@'), false);
            Assert.AreEqual(_presentationModel.PriceRule('\b'), true);
        }

        // 測試 ConfirmPath method
        [TestMethod()]
        public void ConfirmPathTest()
        {
            _presentationModel.ConfirmPath("name", "path");
            Assert.AreEqual(_target.GetField("_isPathTextBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isPathTextBoxAvailable"), true);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmPath("name", "/Image/path");
            Assert.AreEqual(_target.GetField("_isPathTextBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isPathTextBoxAvailable"), false);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmPath("name", "");
            Assert.AreEqual(_target.GetField("_isPathTextBoxNull"), true);
        }

        // 測試 ConfirmDescription method
        [TestMethod()]
        public void ConfirmDescriptionTest()
        {
            _presentationModel.ConfirmDescription("name", "modify desc");
            Assert.AreEqual(_target.GetField("_isDescriptionTextBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isDescriptionTextBoxAvailable"), true);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmDescription("name", "desc");
            Assert.AreEqual(_target.GetField("_isDescriptionTextBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isDescriptionTextBoxAvailable"), false);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmDescription("name", "");
            Assert.AreEqual(_target.GetField("_isDescriptionTextBoxNull"), true);
        }

        // 測試 ConfirmCategory method
        [TestMethod()]
        public void ConfirmCategoryTest()
        {
            _presentationModel.ConfirmCategory("name", 0);
            Assert.AreEqual(_target.GetField("_isCategoryComboBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isCategoryComboBoxAvailable"), true);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmCategory("name", 6);
            Assert.AreEqual(_target.GetField("_isCategoryComboBoxNull"), false);
            Assert.AreEqual(_target.GetField("_isCategoryComboBoxAvailable"), false);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmCategory("name", -1);
            Assert.AreEqual(_target.GetField("_isCategoryComboBoxNull"), true);
        }

        // 測試 IsModifyButtonEnable method
        [TestMethod()]
        public void IsModifyButtonEnableTest()
        {
            _presentationModel.ConfirmName("name", "name");
            _presentationModel.ConfirmPrice("name", "9999999");
            _presentationModel.ConfirmPath("name", "../../../Image/path");
            _presentationModel.ConfirmDescription("name", "desc");
            _presentationModel.ConfirmCategory("name", 6);
            _presentationModel.ConfirmName("name", "modify name");
            Assert.AreEqual(_presentationModel.IsModifyButtonEnable, true);
            _presentationModel.ConfirmName("name", "");
            Assert.AreEqual(_presentationModel.IsModifyButtonEnable, false);
            _presentationModel.ClickAddProductButton();
            _presentationModel.ConfirmName("name", "");
            _presentationModel.ConfirmPrice("name", "");
            _presentationModel.ConfirmPath("name", "");
            _presentationModel.ConfirmDescription("name", "");
            _presentationModel.ConfirmCategory("name", -1);
            JudgeIsModifyButtonEnableWithType();
        }

        // 測試 IsAvailable method
        [TestMethod()]
        public void IsAvailableTest()
        {
            _presentationModel.ConfirmName("name", "name");
            _presentationModel.ConfirmPrice("name", "9999999");
            _presentationModel.ConfirmPath("name", "/Image/path");
            _presentationModel.ConfirmDescription("name", "desc");
            _presentationModel.ConfirmCategory("name", 6);
            Assert.AreEqual(_target.Invoke("IsAvailable"), false);
            _presentationModel.ConfirmName("name", "modify name");
            Assert.AreEqual(_target.Invoke("IsAvailable"), true);
        }

        // 測試 IsNotNull method
        [TestMethod()]
        public void IsNotNullTest()
        {
            _presentationModel.ConfirmName("name", "");
            _presentationModel.ConfirmPrice("name", "");
            _presentationModel.ConfirmPath("name", "");
            _presentationModel.ConfirmDescription("name", "");
            _presentationModel.ConfirmCategory("name", -1);
            Assert.AreEqual(_target.Invoke("IsNotNull"), false);
            _presentationModel.ConfirmName("name", "name");
            Assert.AreEqual(_target.Invoke("IsNotNull"), false);
            _presentationModel.ConfirmPrice("name", "9999999");
            Assert.AreEqual(_target.Invoke("IsNotNull"), false);
            _presentationModel.ConfirmPath("name", "../../../Image/path");
            Assert.AreEqual(_target.Invoke("IsNotNull"), false);
            _presentationModel.ConfirmDescription("name", "desc");
            Assert.AreEqual(_target.Invoke("IsNotNull"), false);
            _presentationModel.ConfirmCategory("name", 6);
            Assert.AreEqual(_target.Invoke("IsNotNull"), true);
        }

        // 測試 AddCategory method
        [TestMethod()]
        public void AddCategoryTest()
        {
            _presentationModel.AddCategory("add category");
            Assert.AreEqual(_model.GetProductCategoryName(7), "add category");
            Assert.AreEqual(_presentationModel.IsAddCategoryState, false);
            Assert.AreEqual(_presentationModel.IsModifyCategoryButtonEnable, false);
            Assert.AreEqual(_isModelNotify, true);
            Assert.AreEqual(_isListNotify, true);
        }

        // 測試 ClickAddCategoryButton method
        [TestMethod()]
        public void ClickAddCategoryButtonTest()
        {
            _presentationModel.ClickAddCategoryButton();
            Assert.AreEqual(_presentationModel.EditType, EditType.Add);
            Assert.AreEqual(_presentationModel.IsAddCategoryState, true);
            Assert.AreEqual(_isModelNotify, true);
        }

        // 測試 ConfirmCategoryName method
        [TestMethod()]
        public void ConfirmCategoryNameTest()
        {
            _presentationModel.SelectCategoryItem();
            _isModelNotify = false;
            _presentationModel.ConfirmCategoryName("add category");
            Assert.AreEqual(_isModelNotify, false);
            _presentationModel.ClickAddCategoryButton();
            _presentationModel.ConfirmCategoryName("");
            Assert.AreEqual(_presentationModel.IsModifyCategoryButtonEnable, false);
            Assert.AreEqual(_isModelNotify, true);
            _presentationModel.ConfirmCategoryName("add category");
            Assert.AreEqual(_presentationModel.IsModifyCategoryButtonEnable, true);
            Assert.AreEqual(_isModelNotify, true);
        }

        // 測試 SelectCategoryItem method
        [TestMethod()]
        public void SelectCategoryItemTest()
        {
            _presentationModel.SelectCategoryItem();
            Assert.AreEqual(_presentationModel.IsAddCategoryState, false);
            Assert.AreEqual(_isModelNotify, true);
        }

        // 測試 IsAddCategoryState method
        [TestMethod()]
        public void IsAddCategoryStateTest()
        {
            Assert.AreEqual(_presentationModel.IsAddCategoryState, false);
            _presentationModel.ClickAddCategoryButton();
            Assert.AreEqual(_presentationModel.IsAddCategoryState, true);
        }

        // 測試 IsModifyCategory method
        [TestMethod()]
        public void IsModifyCategoryTest()
        {
            Assert.AreEqual(_presentationModel.IsModifyCategoryButtonEnable, false);
            _presentationModel.ClickAddCategoryButton();
            _presentationModel.ConfirmCategoryName("add category");
            Assert.AreEqual(_presentationModel.IsModifyCategoryButtonEnable, true);
        }

        // 判斷 RefreshEnableState 被觸發
        private void JudgeRefreshEnableStateBeTriggerd()
        {
            Assert.AreEqual(_presentationModel.IsAddProductButtonEnable, true);
            Assert.AreEqual(_target.GetField("_isNameTextBoxAvailable"), false);
            Assert.AreEqual(_target.GetField("_isPriceTextBoxAvailable"), false);
            Assert.AreEqual(_target.GetField("_isPathTextBoxAvailable"), false);
            Assert.AreEqual(_target.GetField("_isDescriptionTextBoxAvailable"), false);
            Assert.AreEqual(_target.GetField("_isCategoryComboBoxAvailable"), false);
        }

        // 判斷 SetNull 被觸發
        private void JudgeSetNullBeTriggerd(bool flag)
        {
            Assert.AreEqual(_target.GetField("_isNameTextBoxNull"), flag);
            Assert.AreEqual(_target.GetField("_isPriceTextBoxNull"), flag);
            Assert.AreEqual(_target.GetField("_isPathTextBoxNull"), flag);
            Assert.AreEqual(_target.GetField("_isDescriptionTextBoxNull"), flag);
            Assert.AreEqual(_target.GetField("_isCategoryComboBoxNull"), flag);
        }

        // 判斷不同 EditType 的 IsModifyButtonEnable
        private void JudgeIsModifyButtonEnableWithType()
        {
            Assert.AreEqual(_presentationModel.IsModifyButtonEnable, false);
            _presentationModel.ConfirmName("name", "modify name");
            Assert.AreEqual(_presentationModel.IsModifyButtonEnable, false);
            _presentationModel.ConfirmPrice("name", "1");
            Assert.AreEqual(_presentationModel.IsModifyButtonEnable, false);
            _presentationModel.ConfirmPath("name", "path");
            Assert.AreEqual(_presentationModel.IsModifyButtonEnable, false);
            _presentationModel.ConfirmDescription("name", "modify desc");
            Assert.AreEqual(_presentationModel.IsModifyButtonEnable, false);
            _presentationModel.ConfirmCategory("name", 0);
            Assert.AreEqual(_presentationModel.IsModifyButtonEnable, true);
        }
    }
}