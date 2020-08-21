namespace PxWebComparer.Services
{
     public interface ISavedQueryService
     {
         string GetSavedQuery(string url);
         string PostSavedQuery();
         void SaveToFile(string content, string fileName, string contentType, string path);

     }
}
