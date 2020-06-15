using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PxWebComparer.Model;
using PxWebComparer.Model.Enums;

namespace PxWebComparer.Repo
{
    public class FileCompareRepo : IFileCompareRepo
    {
        public void CreateFolder(string path)
        {
            throw new System.NotImplementedException();
        }

        public void SaveContentToFile(string content, OutputFormat outputFormat)
        {
            throw new System.NotImplementedException();
        }

        public void SaveContentToFile(string content, OutputFormat outputFormat, string path)
        {
            //using (System.IO.StreamWriter file =
            //    new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
            //{
            //    foreach (string line in lines)
            //    {
            //        // If the line doesn't contain the word 'Second', write the line to the file.
            //        if (!line.Contains("Second"))
            //        {
            //            file.WriteLine(line);
            //        }
            //    }
            //}


        }

        public void DeleteFolder(string path)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteFile(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public void SaveToFile(CompareResultModel compareResultModel, string path)
        {
            
            var json = File.ReadAllText(path);
//            var compareResults = JsonConvert.DeserializeObject<List<CompareResultModel>>(json);

            var compareResults = JsonConvert.DeserializeObject<CompareResultModel>(json);

            //compareResults.Add(compareResultModel);
            File.WriteAllText(path, JsonConvert.SerializeObject(compareResults));
        }
        
        //private static bool IsValidJson(string strInput)
        //{
        //    strInput = strInput.Trim();
        //    if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
        //        (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
        //    {
        //        try
        //        {
        //            var obj = JToken.Parse(strInput);
        //            return true;
        //        }
        //        catch (JsonReaderException jex)
        //        {
        //            //Exception in parsing json
        //            Console.WriteLine(jex.Message);
        //            return false;
        //        }
        //        catch (Exception ex) //some other exception
        //        {
        //            Console.WriteLine(ex.ToString());
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
