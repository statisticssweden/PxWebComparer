using System;
using System.IO;
using System.Net;
using System.Text;

namespace PxWebComparer.Services
{
    public class SavedQueryService : ISavedQueryService
    {
        public string GetSavedQuery(string url)
        {
            string resultString = string.Empty;

            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            resultString = reader.ReadToEnd();
                        }
                    }
            }
            return resultString;
        }
        
        public void SaveFile(string url, string fileName, string savedQueryFormat, string path)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (WebResponse response = request.GetResponse())
            {
                using (Stream fs = File.Create($"{path}/{fileName}.{savedQueryFormat}"))
                {
                    response.GetResponseStream().CopyTo(fs);
                }
            }
        }

        public void SaveToFile(string content, string fileName, string savedQueryFormat, string path)
        {
            var file = new FileInfo($@"{path}\{fileName}.{savedQueryFormat}");
            file.Directory.Create();
            
            File.WriteAllText(
                Path.Combine(path, $"{fileName}_{savedQueryFormat}.txt"),
                content,
                Encoding.UTF8);
        }

    }   
}
