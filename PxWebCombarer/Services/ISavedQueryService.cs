using System.IO;
using System.Net.Http;

namespace PxWebComparer.Services
{
     public interface ISavedQueryService
     {
         string GetSavedQuery(string url);
         void SaveToFile(string content, string fileName, string contentType, string path);
     }
}
