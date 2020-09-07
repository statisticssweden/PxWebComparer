using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
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

        public void DeleteFirstRowInFile(string path)
        {
            var lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Skip(1).ToArray());
        }

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
