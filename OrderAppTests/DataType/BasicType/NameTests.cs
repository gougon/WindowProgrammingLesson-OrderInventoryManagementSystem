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
    public class NameTests
    {
        Name _name;

        // 初始化 test
        [TestInitialize()]
        public void Initialize()
        {
            _name = new Name("first", "last");
        }

        // 測試constructor
        [TestMethod()]
        public void NameTest()
        {
            Assert.AreEqual(_name.FirstName, "first");
            Assert.AreEqual(_name.LastName, "last");
            _name = new Name();
            Assert.AreEqual(_name.FirstName, "");
            Assert.AreEqual(_name.LastName, "");
        }

        // 測試FirstName
        [TestMethod()]
        public void FirstNameTest()
        {
            _name.FirstName = "modify first";
            Assert.AreEqual(_name.FirstName, "modify first");
        }

        // 測試LastName
        [TestMethod()]
        public void LastNameTest()
        {
            _name.LastName = "modify last";
            Assert.AreEqual(_name.LastName, "modify last");
        }
    }
}