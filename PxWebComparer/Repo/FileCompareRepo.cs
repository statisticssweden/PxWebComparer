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


       


        JToken GetParent(JToken token, int parent = 0)
        {
            if (token == null)
                return null;
            if (parent < 0)
                throw new ArgumentOutOfRangeException("Must be positive");

            var skipTokens = new[]
            {
                typeof(JProperty),
            };
            return token.Ancestors()
                .Where(a => skipTokens.All(t => !t.IsInstanceOfType(a)))
                .Skip(parent)
                .FirstOrDefault();
        }

        public SavedQuery ReadFromFileJson(string path)
        {
            return JsonConvert.DeserializeObject<SavedQuery>(File.ReadAllText(path));
        }

    }
}
