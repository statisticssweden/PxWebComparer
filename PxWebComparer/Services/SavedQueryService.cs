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

        //public Stream GetSavedQueryStream(string url)
        //{
        //    //// string resultString = string.Empty;
        //    // try
        //    // {
        //    //     HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    //     //request.AutomaticDecompression = DecompressionMethods.GZip;

        //    //     using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //    //         if (response.StatusCode == HttpStatusCode.OK)
        //    //         {
        //    //             return response.GetResponseStream();
        //    //             //using (Stream stream = response.GetResponseStream())
        //    //             //using (StreamReader reader = new StreamReader(stream))
        //    //             //{
        //    //             //    resultString = reader.ReadToEnd();
        //    //             //}
        //    //         }
        //    // }

        //    // catch (WebException e)
        //    // {
        //    //     Console.WriteLine("\r\nWebException Raised. The following error occurred : {0}", e.Status);
        //    // }
        //    // catch (Exception e)
        //    // {
        //    //     Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
        //    // }


        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //    {
        //        using (Stream responseStream = response.GetResponseStream())
        //        {
        //            using (Stream outputStream = new FileStream())
        //            {
        //                responseStream.CopyTo(outputStream);
        //            }
        //        }
        //    }

        //}


        //public Stream GetSavedQueryStream(string url)
        //{
        //    //// string resultString = string.Empty;
        //    // try
        //    // {
        //    //     HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    //     //request.AutomaticDecompression = DecompressionMethods.GZip;

        //    //     using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //    //         if (response.StatusCode == HttpStatusCode.OK)
        //    //         {
        //    //             return response.GetResponseStream();
        //    //             //using (Stream stream = response.GetResponseStream())
        //    //             //using (StreamReader reader = new StreamReader(stream))
        //    //             //{
        //    //             //    resultString = reader.ReadToEnd();
        //    //             //}
        //    //         }
        //    // }

        //    // catch (WebException e)
        //    // {
        //    //     Console.WriteLine("\r\nWebException Raised. The following error occurred : {0}", e.Status);
        //    // }
        //    // catch (Exception e)
        //    // {
        //    //     Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
        //    // }


        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //    {
        //        using (Stream responseStream = response.GetResponseStream())
        //        {
        //            using (Stream outputStream = new FileStream())
        //            {
        //                responseStream.CopyTo(outputStream);
        //            }
        //        }
        //    }

        //}

        public void SaveFile(string url, string fileName, string savedQueryFormat, string path)
        {
            //string content = string.Empty;

            //// set up request/response
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //var response = (HttpWebResponse)request.GetResponse();
            //var stream = response.GetResponseStream();

            //// read response content
            //using (var reader = new StreamReader(stream ?? new MemoryStream(), Encoding.UTF8))
            //    content = reader.ReadToEnd();

            //// write to file on desktop
            //File.WriteAllText(
            //    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{path}/{fileName}.{savedQueryFormat}"),
            //    content,
            //    Encoding.UTF8);



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

        //public void SaveToFile(Stream stream, string fileName, string savedQueryFormat, string path)
        //{
        //    //var file = new FileInfo($@"{path}\{fileName}.{savedQueryFormat}");
        //    //file.Directory.Create();


        //    FileStream fileStream = File.Create(path, (int)stream.Length);
        //    // Initialize the bytes array with the stream length and then fill it with data
        //    byte[] bytesInStream = new byte[stream.Length];
        //    stream.Read(bytesInStream, 0, bytesInStream.Length);
        //    // Use write method to write to the file specified above
        //    fileStream.Write(bytesInStream, 0, bytesInStream.Length);
        //    //Close the filestream
        //    fileStream.Close();


        //    //using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
        //    //{
        //    //    content.CopyTo(fileStream);
        //    //}

        //    //File.WriteAllBytes( );
        //    //File.WriteAllText(
        //    //    Path.Combine(path, $"{fileName}_{savedQueryFormat}.txt"),
        //    //    content,
        //    //    Encoding.UTF8);
        //}
    }   
}
