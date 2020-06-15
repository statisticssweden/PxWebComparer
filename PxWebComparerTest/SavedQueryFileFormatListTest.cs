using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PxWebComparer.Repo;

namespace PxWebComparerTest
{
    [TestClass]
    public class SavedQueryFileFormatListTest
    {
        [TestMethod]
        public void ShouldReturnSavedQueryList()
        {
            var repo = new SavedQueryFileFormatRepo();
            var path = @"C:\Temp\PxWebComparerTest\ThreeQueryFile.txt";
            var result = repo.GetSavedQueryFileFormat(path);

        }


    }
}
