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

        public void DeleteAllFilesInFolder(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
        
        public void DeleteFile(string fileName)
        {
           // throw new System.NotImplementedException();
            File.Delete(fileName);
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
    }
}
