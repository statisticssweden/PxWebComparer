using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;
using PxWebComparer.Model;
using PxWebComparer.Model.Enums;
using PxWebComparer.Repo;
using PxWebComparer.Services;

namespace PxWebComparer.Business
{
    public class CompareHandler : ICompareHandler
    {

        private readonly AppSettingsHandler _appSettingsHandler = new AppSettingsHandler();
        private readonly SavedQueryService _savedQueryService = new SavedQueryService();
        private readonly SavedQueryFileFormatRepo _repo = new SavedQueryFileFormatRepo();

        public void Compare()
        {
            
            // get url for api site 1
            var serverAddress1 = _appSettingsHandler.ReadSetting("WebApiAddress1");
            // get url for api site 2
            var serverAddress2 = _appSettingsHandler.ReadSetting("WebApiAddress2");

            var queryTextListPath = _appSettingsHandler.ReadSetting("queryTextListPath");

            var resultFolder1 = _appSettingsHandler.ReadSetting("ResultFolder1");
            var resultFolder2 = _appSettingsHandler.ReadSetting("ResultFolder2");
            var compareResultFile = _appSettingsHandler.ReadSetting("CompareResultFile");
            var fileRepo = new FileCompareRepo();
            var compareResultModelList = new List<CompareResultModel>();

            var queryList = _repo.GetSavedQueryFileFormat(queryTextListPath);

            fileRepo.DeleteAllFilesInFolder(resultFolder1);
            fileRepo.DeleteAllFilesInFolder(resultFolder2);

            try
            {
                foreach (var query in queryList)
                {
                    var compareResultModel = new CompareResultModel();

                    compareResultModel.SavedQuery = query;
                   
                    var outputFormats = Enum.GetValues(typeof(OutputFormat)).Cast<OutputFormat>();
                    
                    foreach (var outputFormat in outputFormats)
                    {
                        _savedQueryService.SaveToFile(_savedQueryService.GetSavedQuery($"{serverAddress1}{query}.{outputFormat}"), query,
                            outputFormat.ToString(), $"{resultFolder1}\\{query}\\");
                        
                            _savedQueryService.SaveToFile(_savedQueryService.GetSavedQuery($"{serverAddress2}{query}.{outputFormat}"), query,
                            outputFormat.ToString(), $"{resultFolder2}\\{query}\\");

                        Thread.Sleep(1000);

                        var result = CompareSavedQueryResults($@"{resultFolder1}\{query}\{query}_{outputFormat}.txt",
                            $@"{resultFolder2}\{query}\{query}_{outputFormat}.txt");

                        compareResultModel.UpdateModel(outputFormat, result);
                    }

                    compareResultModelList.Add(compareResultModel);
                }
                    
                fileRepo.DeleteFile(compareResultFile);
                fileRepo.SaveToFile(compareResultModelList, compareResultFile);
                var resultFile = fileRepo.ReadFromFile(compareResultFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public bool CompareSavedQueryResults(string filePath1, string filePath2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (filePath1 == filePath2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(filePath1, FileMode.Open);
            fs2 = new FileStream(filePath2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1byte - file2byte) == 0);


        }

        public List<CompareResultModel> GetResults()
        {
            var compareResultFile = _appSettingsHandler.ReadSetting("CompareResultFile");
            var fileRepo = new FileCompareRepo();
            return fileRepo.ReadFromFile(compareResultFile);
        }
     
    }
}
