using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PxWebComparer.Model;
using PxWebComparer.Model.Enums;


namespace PxWebComparer.Services
{
    public class SavedQueryService : ISavedQueryService
    {
        public string GetService(string url)
        {
            string resultString = string.Empty;

            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                try
                {

                    using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            using (Stream stream = response.GetResponseStream())
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                resultString = reader.ReadToEnd();
                            }
                        }
                        else
                        {
                            return null;
                        }
                }
                catch (WebException)
                {
                    return null;
                }

            }
            return resultString;
        }
        

          public bool PostAndSaveAsFileService(string url, TableQuery tableQuery, string fileName)
          { 
            var stringPayload = JsonConvert.SerializeObject(tableQuery);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                  var httpResponse = httpClient.PostAsync(url, httpContent);

                  if (httpResponse.Result != null)
                  {
                      using (Stream fs = File.Create($"{fileName}"))
                      {
                        httpResponse.Result.Content.CopyToAsync(fs); 
                      }
                  }
                  else
                  {
                      return false;
                  }
                  return true;
            }

          }
        
          public bool GetAndSaveAsFile(string url, string fileName, string savedQueryFormat, string path)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream fs = File.Create($"{path}/{fileName}.{savedQueryFormat}"))
                    {
                        response.GetResponseStream().CopyTo(fs);
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
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
