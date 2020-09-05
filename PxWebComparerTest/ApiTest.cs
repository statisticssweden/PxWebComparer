using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PxWebComparer.Services;

namespace PxWebComparerTest
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public void ShouldPostAndGetResult()
        {
            TestFactory factory = new TestFactory();
            SavedQueryService savedQueryService = new SavedQueryService();


            var url = "http://api.scb.se/OV0104/v1/doris/sv/ssd/START/JO/JO1104/F3ny";
            var tableQuery = factory.GetTableQuery();

            savedQueryService.PostService(url, tableQuery);

        }



    }
}
