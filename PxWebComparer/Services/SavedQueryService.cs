using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using PxWebComparer.Model;


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
                catch (WebException e)
                {
                    string error = e.Message;
                    return null;
                }

            }
            return resultString;
        }



        public string PostService(string url, TableQuery tableQuery)
        {
            string resultString = string.Empty;

            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    request.ContentType = "application/json";
                    request.Method = "POST";

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(tableQuery);
                        streamWriter.Write(json);
                    }

                    var httpResponse = (HttpWebResponse)request.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        resultString = streamReader.ReadToEnd();
                    }
                }
                catch (WebException e)
                {
                    return null;
                }
            }
            return resultString;
        }
        
        public bool PostAndSaveAsFile(string url, string fileName, string savedQueryFormat, string path, TableQuery tableQuery)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(tableQuery);
                streamWriter.Write(json);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
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
