
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PxWebComparer.Business;
using PxWebComparer.Model;
using PxWebComparer.Services;

namespace PxWebComparerTest
{
    [TestClass]
    public class CompareHandlerTest
    {
        [TestMethod]
        public void ShouldMatchMetaTableToQueryTable()
        {
            CompareHandler compareHandler = new CompareHandler();
            TestFactory factory = new TestFactory();
            
            var metaTable = factory.GetMetaTable();
            var tableQuery = compareHandler.MapToTableQuery(metaTable, "px");

            Assert.AreEqual(metaTable.Variables.Length, tableQuery.Query.Length );

        }

        [TestMethod]
        public void ListsShouldBeUnequal()
        {
            CompareHandler compareHandler = new CompareHandler();
            TestFactory factory = new TestFactory();

            var menuItem = factory.GetMenuItemList();
            var reducedMenuItemList = compareHandler.GetReduceList<MenuItem>(menuItem);
            
            Assert.AreNotEqual(menuItem.Count,reducedMenuItemList.Count );
            
        }

        [TestMethod]
        public void ListsShouldBeEqual()
        {
            CompareHandler compareHandler = new CompareHandler();
            TestFactory factory = new TestFactory();

            var menuItem = factory.GetMenuItemListOne();
            var reducedMenuItemList = compareHandler.GetReduceList<MenuItem>(menuItem);

            Assert.AreEqual(menuItem.Count, reducedMenuItemList.Count);

        }

    }
}
