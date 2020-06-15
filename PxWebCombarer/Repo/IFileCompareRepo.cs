using PxWebComparer.Model;
using PxWebComparer.Model.Enums;

namespace PxWebComparer.Repo
{
    public interface IFileCompareRepo
    {
        void CreateFolder(string path);
        void SaveContentToFile(string content, OutputFormat outputFormat );
        void DeleteFolder(string path);
        void DeleteFile(string fileName);

        void SaveToFile(CompareResultModel compareResultModel, string path);

    }
}
