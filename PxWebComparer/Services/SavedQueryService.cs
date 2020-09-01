using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PxWebComparer.Model;



namespace PxWebComparer.Services
{
    public class SavedQueryService : ISavedQueryService
    {
        public string GetSavedQuery(string url)
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
        
        public string PostSavedQuery(string url, TableQuery tableQuery)
        {
            string responseString = string.Empty;


            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //        if (response.StatusCode == HttpStatusCode.OK)
            //        {
            //            using (Stream stream = response.GetResponseStream())
            //            using (StreamReader reader = new StreamReader(stream))
            //            {
            //                responseString = reader.ReadToEnd();
            //            }
            //        }
            //        else
            //        {
            //            return null;
            //        }

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            // Set the 'Method' property of the 'Webrequest' to 'POST'.
            myHttpWebRequest.Method = "POST";

            var stringPayload = JsonConvert.SerializeObject(tableQuery);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");


            using (var httpClient = new HttpClient())
            {

                // Do the actual request and await the response
                //var httpResponse = httpClient.PostAsync(url, httpContent);

                var httpResponse = httpClient.GetAsync(url);


                // If the response contains content we want to read it!
                if (httpResponse.Result != null)
                {
                    var responseContent = httpResponse.Result.Content.ReadAsStringAsync();

                    // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                }
            }


            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(tableQuery.ToString());

            
            // Set the content type of the data being posted.
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

            // Set the content length of the string being posted.
            myHttpWebRequest.ContentLength = byte1.Length;

            Stream newStream = myHttpWebRequest.GetRequestStream();

            newStream.Write(byte1, 0, byte1.Length);

            //newStream.Write(httpContent, 0, byte1.Length);
            //Console.WriteLine("The value of 'ContentLength' property after sending the data is {0}", myHttpWebRequest.ContentLength);

            using (HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }

            // Close the Stream object.
            newStream.Close();

            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                
             //   ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(tableQuery.ToString());

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            }
            return responseString;
        }

        private TableQuery GetTableQuery()
        {
            TableQuery tableQuery = new TableQuery();

            //tableQuery.Query = new Query[];

            var queryList = new Query[]
            {
                new Query()
                {
                    Code = "Redskap",
                    Selection = new Model.QuerySelection()
                    {
                        Filter = "item",
                        Values = new string[] {"23", "21", "element3"}
                    }
                },
                new Query()
                {
                    Code = "Omrade2",
                    Selection = new Model.QuerySelection()
                    {
                        Filter = "item",
                        Values = new string[] {"23", "21", "element3"}
                    },
                }
            };
            tableQuery.Query = queryList;
            tableQuery.Response.Format = "json";

            return tableQuery;
        }

        public bool SaveFile(string url, string fileName, string savedQueryFormat, string path)
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
