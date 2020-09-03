using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PxWebComparer.Model;

namespace PxWebComparer.Repo
{
    public class FileCompareRepo : IFileCompareRepo
    {
        public void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public void DeleteAllFilesInFolder(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
        }
        
        public void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
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
            File.WriteAllText(path, JsonConvert.SerializeObject(compareResultModelList));
        }

        public void SaveToFile(List<SavedQueryMetaCompareResultModel> savedQueryMetaCompareResultModel, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(savedQueryMetaCompareResultModel));
        }

        public List<CompareResultModel> ReadFromFile(string path)
        {
            var json = File.ReadAllText(path);
           
            return JsonConvert.DeserializeObject<List<CompareResultModel>>(json);
        }

        public List<SavedQueryMetaCompareResultModel> ReadFromSaveCompareResultModels(string path)
        {
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<SavedQueryMetaCompareResultModel>>(json);
        }


        public SavedQuery ReadFromFileJson(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<SavedQuery>(File.ReadAllText(path));
            }
            catch (FileNotFoundException)
            {
                return null;
            }
         
        }

    }
}
