using System.Collections.Generic;
using PxWebComparer.Model;

namespace PxWebComparer.Repo
{
    public interface IFileCompareRepo
    {
        void CreateFolder(string path);
        void DeleteAllFilesInFolder(string path);
        void DeleteFile(string fileName);
  //      void SaveToFile<T>(T model, string path);
        //void SaveToFile(List<CompareResultModel> compareResultModel, string path);
        void SaveToFile<T>(List<T> compareResultModel, string path);
        void DeleteFirstRowInFile(string path);
    }
}
