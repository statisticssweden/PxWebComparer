using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using PxWebComparer.Model;
using PxWebComparer.Model.Enums;
using PxWebComparer.Repo;
using PxWebComparer.Services;

namespace PxWebComparer.Business
{
    public class CompareHandler : ICompareHandler
    {
        public void Compare()
        {
            var helper = new AppSettingsHandler();
            var service = new SavedQueryService();
            var repo = new SavedQueryFileFormatRepo();
            
            // get url for api site 1
            var serverAddress1 = helper.ReadSetting("WebApiAddress1");
            // get url for api site 2
            var serverAddress2 = helper.ReadSetting("WebApiAddress2");
            
            var queryTextListPath = helper.ReadSetting("queryTextListPath");

            var resultFolder1 = helper.ReadSetting("ResultFolder1");
            var resultFolder2 = helper.ReadSetting("ResultFolder2");
            var compareResultFile = helper.ReadSetting("CompareResultFile");
            var fileRepo = new FileCompareRepo();


            var queryList = repo.GetSavedQueryFileFormat(queryTextListPath);

            foreach (var query in queryList)
            {
                var compareResultModel = new CompareResultModel();

                compareResultModel.SavedQuery = new UniqueId(query);
                //compareResultModel.SavedQuery = query;

                var outputFormats = Enum.GetValues(typeof(OutputFormat)).Cast<OutputFormat>();

                foreach (var outputFormat in outputFormats)
                {
                    //SaveToFile(service, serverAddress1, query, resultFolder2);
                   
                   service.SaveToFile(service.GetSavedQuery($"{serverAddress1}{query}.{outputFormat}"), query, outputFormat.ToString(), $"{resultFolder1}\\{query}\\");

                    //var queryResult = service.GetSavedQuery(serverAddress1 + query);
                    service.SaveToFile(service.GetSavedQuery($"{serverAddress1}{query}.{outputFormat}"), query, outputFormat.ToString(), $"{resultFolder2}\\{query}\\");
                    var result = CompareSavedQueryResults($@"{resultFolder1}\{query}\{query}.{outputFormat}", $@"{resultFolder1}\{query}\{query}.{outputFormat}");
                
                    compareResultModel.UpdateModel(outputFormat,result);
                }

                fileRepo.SaveToFile(compareResultModel, compareResultFile);

               
            }



        }

        //public void SaveToFile(SavedQueryService service, string serverAddress, string query, string resultFolder)
        //{
           
        //    string queryFormat = "html";

        //    var queryResult = service.GetSavedQuery(serverAddress + query);
            
        //    service.SaveToFile(queryResult, query, queryFormat, $"{resultFolder}\\{query}\\");
        //}

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

        public void SaveToFile(SavedQueryService service, string serverAddress, string query, string resultFolder)
        {
            throw new NotImplementedException();
        }
    }
}
