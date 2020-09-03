using PxWebComparer.Model;
using PxWebComparer.Model.Enums;

namespace PxWebComparer.Services
{
     public interface ISavedQueryService
     {
         string GetService(string url);
         bool PostAndSaveAsFileService (string url, TableQuery tableQuery, string fileName);
         bool GetAndSaveAsFile(string url, string fileName, string savedQueryFormat, string path);
         void SaveToFile(string content, string fileName, string contentType, string path);

     }
}
