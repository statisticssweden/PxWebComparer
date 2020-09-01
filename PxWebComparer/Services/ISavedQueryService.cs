using PxWebComparer.Model;


namespace PxWebComparer.Services
{
     public interface ISavedQueryService
     {
         string GetSavedQuery(string url);
         string PostSavedQuery(string url, TableQuery query );
         void SaveToFile(string content, string fileName, string contentType, string path);

     }
}
