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
            //url = "http://pxwebdemo.scb.se/sq/2b33e238-8e7e-44ee-bbdf-21a007a4069a.csv";
            string resultString = string.Empty;
            //.csv
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.AutomaticDecompression = DecompressionMethods.GZip;

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
            catch (WebException e)
            {
                Console.WriteLine("\r\nWebException Raised. The following error occurred : {0}", e.Status);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
            }
            return resultString;
        }
        
        public void SaveToFile(string content, string fileName, string savedQueryFormat, string path)
        {
            var file = new FileInfo($@"{path}\{fileName}.{savedQueryFormat}");
            file.Directory.Create();
            
            File.WriteAllText(
                Path.Combine(path, $"{fileName}.{savedQueryFormat}"),
                content,
                Encoding.UTF8);
        }
    }   
}
