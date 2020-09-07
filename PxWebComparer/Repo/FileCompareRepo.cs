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

        //public void SaveToFile(CompareResultModel compareResultModel, string path)
        //{
        //    var json = File.ReadAllText(path);
        //    var compareResults = JsonConvert.DeserializeObject<CompareResultModel>(json);
        //    File.WriteAllText(path, JsonConvert.SerializeObject(compareResults));
        //}

        //public void SaveToFile<T>(T model , string path)
        //{
        //    var json = File.ReadAllText(path);
        //    var compareResults = JsonConvert.DeserializeObject<T>(json);
        //    File.WriteAllText(path, JsonConvert.SerializeObject(compareResults));
        //}



        public List<T> GetReduceList<T>(List<T> list)
        {
            var returnList = new List<T>();

            if (list.Count() > 2)
            {
                returnList.Add(list.First());
                returnList.Add(list.ElementAt(list.Count() / 2));
                returnList.Add(list.Last());
            }
            else
            {
                foreach (var listItem in list)
                {
                    returnList.Add(listItem);
                }
            }

            return returnList;
        }


        public void SaveToFile<T>(List<T> compareResultModelList, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(compareResultModelList));
        }
        
        //public void SaveToFile(List<CompareResultModel> compareResultModelList, string path)
        //{
        //    File.WriteAllText(path, JsonConvert.SerializeObject(compareResultModelList));
        //}

        //public void SaveToFile(List<SavedQueryMetaCompareResultModel> savedQueryMetaCompareResultModel, string path)
        //{
        //    File.WriteAllText(path, JsonConvert.SerializeObject(savedQueryMetaCompareResultModel));
        //}

        public List<T> ReadFromFile<T>(string path)
        {
            try
            {
                var json = File.ReadAllText(path);

                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (IOException)
            {
                return null;
            }
            


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
