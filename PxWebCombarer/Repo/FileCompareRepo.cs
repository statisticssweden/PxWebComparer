using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var compareResults = JsonConvert.DeserializeObject<CompareResultModel>(json);
            File.WriteAllText(path, JsonConvert.SerializeObject(compareResults));
        }

        public void SaveToFile(List<CompareResultModel> compareResultModelList, string path)
        {

            //var json = File.ReadAllText(path);
            //var compareResults = JsonConvert.DeserializeObject<List<CompareResultModel>>(json);
            //compareResults.Add(compareResultModelList);
            File.WriteAllText(path, JsonConvert.SerializeObject(compareResultModelList));

        }


        public List<CompareResultModel> ReadFromFile(string path)
        {
            var json = File.ReadAllText(path);
           
            return JsonConvert.DeserializeObject<List<CompareResultModel>>(json);
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
