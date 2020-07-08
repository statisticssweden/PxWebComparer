using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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
        private readonly ExcelComparer _excelComparer = new ExcelComparer();

        public void Compare()
        {
            
            // get url for api site 1
            var serverAddress1 = _appSettingsHandler.ReadSetting("WebApiAddress1");
            // get url for api site 2
            var serverAddress2 = _appSettingsHandler.ReadSetting("WebApiAddress2");

            var queryTextListPath = _appSettingsHandler.ReadSetting("queryTextListPath");

            var resultFolder1 = _appSettingsHandler.ReadSetting("ResultFolder1") + "/SavedQuery/";
            var resultFolder2 = _appSettingsHandler.ReadSetting("ResultFolder2") + "/SavedQuery/";
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
                        bool result = false;
                        if (outputFormat == OutputFormat.xlsx || outputFormat == OutputFormat.xlsx_doublecolumn)
                        {

                            _savedQueryService.SaveFile($"{serverAddress1}{query}.{outputFormat}", $"{query}_{outputFormat}" ,
                                "xlsx", $"{resultFolder1}\\{query}\\");

                            _savedQueryService.SaveFile($"{serverAddress1}{query}.{outputFormat}", $"{query}_{outputFormat}",
                                "xlsx", $"{resultFolder2}\\{query}\\");

                            Thread.Sleep(1000);

                            var resultList1 = _excelComparer.ReadExcelFile($@"{resultFolder1}\{query}\{query}_{outputFormat}.xlsx");

                            var resultList2 = _excelComparer.ReadExcelFile($@"{resultFolder2}\{query}\{query}_{outputFormat}.xlsx");
                            
                            result = CompareArrayLists(resultList1, resultList2);

                        }
                        else
                        {
                            _savedQueryService.SaveToFile(_savedQueryService.GetSavedQuery($"{serverAddress1}{query}.{outputFormat}"), query,
                            outputFormat.ToString(), $"{resultFolder1}\\{query}\\");

                            _savedQueryService.SaveToFile(_savedQueryService.GetSavedQuery($"{serverAddress2}{query}.{outputFormat}"), query,
                            outputFormat.ToString(), $"{resultFolder2}\\{query}\\");

                            Thread.Sleep(1000);
                        
                        result = CompareSavedQueryResults($@"{resultFolder1}\{query}\{query}_{outputFormat}.txt",
                            $@"{resultFolder2}\{query}\{query}_{outputFormat}.txt");


                        }
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

        public void CompareSavedQueryMetaDabase()
        {
            var fileRepo = new FileCompareRepo();

            var resultFolder1 = _appSettingsHandler.ReadSetting("ResultFolder1") + "/SavedQueryMeta/";
            var resultFolder2 = _appSettingsHandler.ReadSetting("ResultFolder2") + "/SavedQueryMeta/"; ;

            fileRepo.DeleteAllFilesInFolder($"{resultFolder1}");
            fileRepo.DeleteAllFilesInFolder($"{resultFolder2}");

            int savedQueryId1 = 1;
            int savedQueryId2 = 1;
            var repo = new  DatabaseRepo();
            var savedQueryResult1 = repo.GetSavedQueryById(savedQueryId1);
            var savedQueryResult2 = repo.GetSavedQueryById(savedQueryId2);

            _savedQueryService.SaveToFile(savedQueryResult1,savedQueryId1.ToString(), "SavedQueryMeta", $"{resultFolder1}\\{savedQueryId1}\\");
            _savedQueryService.SaveToFile(savedQueryResult2,savedQueryId2.ToString(), "SavedQueryMeta", $"{resultFolder2}\\{savedQueryId2}\\");
            
            var result = CompareSavedQueryResults($@"{resultFolder1}\{savedQueryId1}\{savedQueryId1}_SavedQueryMeta.txt",
                $@"{resultFolder2}\{savedQueryId2}\{savedQueryId2}_SavedQueryMeta.txt");
           
        }

        public void CompareSavedQueryMetaPxsq()
        {
            var fileRepo = new FileCompareRepo();

            var resultFolder1 = _appSettingsHandler.ReadSetting("ResultFolder1") ;
            var resultFolder2 = _appSettingsHandler.ReadSetting("ResultFolder1") ; ;


            var savedQueryId1 = "test1.pxsq";
            var savedQueryId2 = "test2.pxsq";


            var sq1 = fileRepo.ReadFromFileJson(resultFolder1 + "/SavedQueryPxsq/"  + savedQueryId1);

            var sq2 = fileRepo.ReadFromFileJson(resultFolder2 + "/SavedQueryPxsq/" + savedQueryId2);

            var sq1ResultString = SavedQueryString(sq1);
            var sq2ResultString = SavedQueryString(sq2);

            fileRepo.DeleteAllFilesInFolder($"{resultFolder1}/SavedQueryMeta");
            fileRepo.DeleteAllFilesInFolder($"{resultFolder2}/SavedQueryMeta");

            _savedQueryService.SaveToFile(sq1ResultString, savedQueryId1.ToString(), "SavedQueryMeta", $"{resultFolder1}\\SavedQueryMeta\\{savedQueryId1}\\");
            _savedQueryService.SaveToFile(sq2ResultString, savedQueryId2.ToString(), "SavedQueryMeta", $"{resultFolder2}\\SavedQueryMeta\\{ savedQueryId2}\\");

            var result = CompareSavedQueryResults($@"{resultFolder1}\SavedQueryMeta\{savedQueryId1}\{savedQueryId1}_SavedQueryMeta.txt",
                $@"{resultFolder2}\SavedQueryMeta\{savedQueryId2}\{savedQueryId2}_SavedQueryMeta.txt");
            
        }


        public string SavedQueryString(SavedQuery sq)
        {
            var resultString = string.Empty;
            
            foreach (var param in sq.Output.Params)
            {
                resultString = resultString + param.Key + param.Value;
            }

            foreach (var source in sq.Sources)
            {
                resultString = resultString + source.DatabaseId;
                resultString = resultString + source.Default;
                resultString = resultString + source.Id;
                resultString = resultString + source.Language;
                resultString = resultString + source.Source;
                resultString = resultString + source.SourceIdType;
                resultString = resultString + source.Type;
                
                foreach (var query in source.Quieries)
                {

                    resultString = resultString + query.Code;
                    resultString = resultString + query.VariableType;
                    resultString = resultString + query.Selection.Filter;

                    foreach (var value in query.Selection.Values)
                    {
                        resultString = resultString + value;
                    }
                }
            }
            
            foreach (var step in sq.Workflow)
            {
                resultString = resultString + step.Type;
                foreach (var param in step.Params)
                {
                    resultString = resultString + param.Key + param.Value;
                }

            }
            resultString = resultString + sq.Output.Type;
            return resultString;
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

        public bool CompareArrayLists(ArrayList arrayList1, ArrayList arrayList2)
        {
            if (arrayList1.Count != arrayList2.Count)
                return false;


            var maxElements = arrayList1.Count;

            for (int i = 0; i < maxElements; i++)
            {
                if (arrayList1[i].ToString() != arrayList2[i].ToString())
                {
                    return false;
                }
            }

            return true;

        }

        public List<CompareResultModel> GetResults()
        {
            var compareResultFile = _appSettingsHandler.ReadSetting("CompareResultFile");
            var fileRepo = new FileCompareRepo();
            return fileRepo.ReadFromFile(compareResultFile);
        }

    }

}
