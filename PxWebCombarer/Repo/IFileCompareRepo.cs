using System.Collections.Generic;
using PxWebComparer.Model;
using PxWebComparer.Model.Enums;

namespace PxWebComparer.Repo
{
    public interface IFileCompareRepo
    {
        void CreateFolder(string path);
        void DeleteAllFilesInFolder(string path);
        void DeleteFile(string fileName);
        void SaveToFile(CompareResultModel compareResultModel, string path);
        void SaveToFile(List<CompareResultModel> compareResultModel, string path);

    }
}
