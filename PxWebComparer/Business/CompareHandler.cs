using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
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
            var serverAddress1 = _appSettingsHandler.ReadSetting("WebApiAddress1") + $"sq/";
            // get url for api site 2
            var serverAddress2 = _appSettingsHandler.ReadSetting("WebApiAddress2") + $"sq/";

            var queryTextListPath = _appSettingsHandler.ReadSetting("queryTextListPath");

            var resultFolder1 = _appSettingsHandler.ReadSetting("ResultFolder1") + "/SavedQuery/";
            var resultFolder2 = _appSettingsHandler.ReadSetting("ResultFolder2") + "/SavedQuery/";
            var compareResultFile = _appSettingsHandler.ReadSetting("CompareResultFile");
            var fileRepo = new FileCompareRepo();
            var compareResultModelList = new List<CompareResultModel>();

            var queryList = _repo.GetSavedQueryFileFormat(queryTextListPath);

            fileRepo.DeleteAllFilesInFolder(resultFolder1);
            fileRepo.DeleteAllFilesInFolder(resultFolder2);
            {
                foreach (var query in queryList)
                {
                    var compareResultModel = new CompareResultModel {SavedQuery = query};

                    var outputFormats = Enum.GetValues(typeof(OutputFormat)).Cast<OutputFormat>();

                    foreach (var outputFormat in outputFormats)
                    {
                        bool saveQuery1;
                        bool saveQuery2;
                        bool? result;

                        if (outputFormat == OutputFormat.xlsx || outputFormat == OutputFormat.xlsx_doublecolumn)
                        {

                            saveQuery1 = _savedQueryService.GetAndSaveAsFile($"{serverAddress1}{query}.{outputFormat}",
                                $"{query}_{outputFormat}",
                                "xlsx", $"{resultFolder1}\\{query}\\");

                            saveQuery2 = _savedQueryService.GetAndSaveAsFile($"{serverAddress1}{query}.{outputFormat}",
                                $"{query}_{outputFormat}",
                                "xlsx", $"{resultFolder2}\\{query}\\");

                            Thread.Sleep(1000);

                            if (saveQuery1 && saveQuery2)
                            {
                                var resultList1 =
                                    _excelComparer.ReadExcelFile(
                                        $@"{resultFolder1}\{query}\{query}_{outputFormat}.xlsx");
                                var resultList2 =
                                    _excelComparer.ReadExcelFile(
                                        $@"{resultFolder2}\{query}\{query}_{outputFormat}.xlsx");
                                result = CompareArrayLists(resultList1, resultList2);
                            }
                            else
                            {
                                result = null;
                            }
                        }
                        else
                        {
                            var res1 = _savedQueryService.GetService($"{serverAddress1}{query}.{outputFormat}");

                            var res2 = _savedQueryService.GetService($"{serverAddress2}{query}.{outputFormat}");

                            Thread.Sleep(1000);

                            if (res1 != null && res2 != null)
                            {
                                _savedQueryService.SaveToFile(res1, query, outputFormat.ToString(),
                                    $"{resultFolder1}\\{query}\\");
                                _savedQueryService.SaveToFile(res2, query, outputFormat.ToString(),
                                    $"{resultFolder2}\\{query}\\");

                                result = CompareSavedQueryResults(
                                    $@"{resultFolder1}\{query}\{query}_{outputFormat}.txt",
                                    $@"{resultFolder2}\{query}\{query}_{outputFormat}.txt");

                            }
                            else
                            {
                                result = null;
                            }

                        }

                        compareResultModel.UpdateModel(outputFormat, result);
                    }

                    compareResultModelList.Add(compareResultModel);
                }

                fileRepo.DeleteFile(compareResultFile);
                fileRepo.SaveToFile(compareResultModelList, compareResultFile);
                var resultFile = fileRepo.ReadFromFile(compareResultFile);
            }
        }

        public void CompareSavedQueryMetaDatabase()
        {
            var fileRepo = new FileCompareRepo();
            var compareResultModelList = new List<CompareResultModel>();
            var savedQueryMetaCompareResultModel = new List<SavedQueryMetaCompareResultModel>();
            var connstring1 = _appSettingsHandler.ReadSetting("SavedQueryConnectionString1");
            var connstring2 = _appSettingsHandler.ReadSetting("SavedQueryConnectionString2");

            var compareResultFile = _appSettingsHandler.ReadSetting("CompareSavedQueryResultFile");

            var resultFolder1 = _appSettingsHandler.ReadSetting("ResultFolder1") + "/SavedQueryMeta/";
            var resultFolder2 = _appSettingsHandler.ReadSetting("ResultFolder2") + "/SavedQueryMeta/";
            ;

            fileRepo.DeleteAllFilesInFolder($"{resultFolder1}");
            fileRepo.DeleteAllFilesInFolder($"{resultFolder2}");

            var repo = new DatabaseRepo();

            var savedQueries = repo.GetSavedQueries(connstring1, 10);

            foreach (var savedQuery in savedQueries)
            {


                var savedQueryResult1 = repo.GetSavedQueryById(savedQuery, connstring1);
                var savedQueryResult2 = repo.GetSavedQueryById(savedQuery, connstring2);

                if (savedQueryResult1 != string.Empty && savedQueryResult2 != string.Empty)
                {
                    _savedQueryService.SaveToFile(savedQueryResult1, savedQuery, "SavedQueryMeta",
                        $"{resultFolder1}\\{savedQuery}\\");
                    _savedQueryService.SaveToFile(savedQueryResult2, savedQuery, "SavedQueryMeta",
                        $"{resultFolder2}\\{savedQuery}\\");

                    var result = CompareSavedQueryResults(
                        $@"{resultFolder1}\{savedQuery}\{savedQuery}_SavedQueryMeta.txt",
                        $@"{resultFolder2}\{savedQuery}\{savedQuery}_SavedQueryMeta.txt");

                    savedQueryMetaCompareResultModel.Add(new SavedQueryMetaCompareResultModel()
                        {Id = savedQuery, Result = result});
                }
                else
                {
                    savedQueryMetaCompareResultModel.Add(new SavedQueryMetaCompareResultModel()
                        {Id = savedQuery, Result = null});
                }
            }

            fileRepo.DeleteFile(compareResultFile);
            fileRepo.SaveToFile(savedQueryMetaCompareResultModel, compareResultFile);
        }

        public void CompareSavedQueryMetaPxsq()
        {
            var fileRepo = new FileCompareRepo();
            var savedQueryMetaCompareResultModel = new List<SavedQueryMetaCompareResultModel>();
            var compareResultFile = _appSettingsHandler.ReadSetting("CompareSavedQueryResultFile");

            var pxsqFolder1 = _appSettingsHandler.ReadSetting("SQFileFormat1");
            var pxsqFolder2 = _appSettingsHandler.ReadSetting("SQFileFormat1");

            var resultFolder1 = _appSettingsHandler.ReadSetting("ResultFolder1");
            var resultFolder2 = _appSettingsHandler.ReadSetting("ResultFolder2");


            var directory = new DirectoryInfo(pxsqFolder1);
            var masks = new[] {"*.pxsq"};
            var savedQueryIds = masks.SelectMany(directory.EnumerateFiles);

            fileRepo.DeleteAllFilesInFolder($"{_appSettingsHandler.ReadSetting("ResultFolder1")}/SavedQueryMeta/");
            fileRepo.DeleteAllFilesInFolder($"{_appSettingsHandler.ReadSetting("ResultFolder2")}/SavedQueryMeta/");

            foreach (var savedQueryId in savedQueryIds)
            {
                var sqId = savedQueryId.Name.Substring(0, savedQueryId.Name.LastIndexOf("."));

                var sq1 = fileRepo.ReadFromFileJson($"{pxsqFolder1}\\{savedQueryId.Name}");
                var sq2 = fileRepo.ReadFromFileJson($"{pxsqFolder2}\\{savedQueryId.Name}");

                if (sq1 != null && sq2 != null)
                {
                    var sq1ResultString = SavedQueryString(sq1);
                    var sq2ResultString = SavedQueryString(sq2);

                    _savedQueryService.SaveToFile(sq1ResultString, sqId, "SavedQueryMeta",
                        $"{resultFolder1}\\SavedQueryMeta\\{sqId}\\");
                    _savedQueryService.SaveToFile(sq2ResultString, sqId, "SavedQueryMeta",
                        $"{resultFolder2}\\SavedQueryMeta\\{sqId}\\");

                    var result = CompareSavedQueryResults(
                        $@"{resultFolder1}\SavedQueryMeta\{sqId}\{sqId}_SavedQueryMeta.txt",
                        $@"{resultFolder2}\SavedQueryMeta\{sqId}\{sqId}_SavedQueryMeta.txt");
                    savedQueryMetaCompareResultModel.Add(new SavedQueryMetaCompareResultModel()
                        {Id = sqId, Result = result});
                }
                else
                {
                    savedQueryMetaCompareResultModel.Add(new SavedQueryMetaCompareResultModel()
                        {Id = sqId, Result = null});
                }

            }

            fileRepo.DeleteFile(compareResultFile);
            fileRepo.SaveToFile(savedQueryMetaCompareResultModel, compareResultFile);
        }


        //Unittest to this one
        public string SavedQueryString(SavedQuery sq)
        {
            var resultString = string.Empty;

            foreach (var param in sq.Output.Params)
            {
                resultString = resultString + param.Key + param.Value;
            }

            foreach (var source in sq.Sources)
            {
                resultString += source.DatabaseId;
                resultString += source.Default;
                resultString += source.Id;
                resultString += source.Language;
                resultString += source.Source;
                resultString += source.SourceIdType;
                resultString += source.Type;

                foreach (var query in source.Quieries)
                {

                    resultString += query.Code;
                    resultString += query.VariableType;
                    resultString += query.Selection.Filter;

                    foreach (var value in query.Selection.Values)
                    {
                        resultString += value;
                    }
                }
            }

            foreach (var step in sq.Workflow)
            {
                resultString += step.Type;
                foreach (var (key, value) in step.Params)
                {
                    resultString = resultString + key + value;
                }

            }

            resultString += sq.Output.Type;
            return resultString;
        }

        //Unittest to this one
        public bool CompareSavedQueryResults(string filePath1, string filePath2)
        {
            int file1Byte;
            int file2Byte;
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
                file1Byte = fs1.ReadByte();
                file2Byte = fs2.ReadByte();
            } while ((file1Byte == file2Byte) && (file1Byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1Byte - file2Byte) == 0);


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

        public void CompareApi()
        {

            // get url for api site 1
            var serverAddress1 = _appSettingsHandler.ReadSetting("WebApiAddress1");
            // get url for api site 2
            var serverAddress2 = _appSettingsHandler.ReadSetting("WebApiAddress2");

            var queryTextListPath = _appSettingsHandler.ReadSetting("queryTextListPath");

            var resultFolder1 = _appSettingsHandler.ReadSetting("ResultFolder1") + "/Api/";
            var resultFolder2 = _appSettingsHandler.ReadSetting("ResultFolder2") + "/Api/";
            var compareResultFile = _appSettingsHandler.ReadSetting("CompareApiResultFile");
            var fileRepo = new FileCompareRepo();
            var compareResultModelList = new List<CompareResultModel>();


            fileRepo.DeleteAllFilesInFolder(resultFolder1);
            fileRepo.DeleteAllFilesInFolder(resultFolder2);

            string qStringGlobal = string.Empty;

            qStringGlobal = $"api/v1/sv";

            qStringGlobal += $"/ssd";

            var menuItems =
                JsonConvert.DeserializeObject<IEnumerable<MenuItem>>(
                    _savedQueryService.GetService(serverAddress1 + qStringGlobal));

            if (!menuItems.Any())
                return;

            menuItems = GetReduceList<MenuItem>(menuItems.ToList());

           // menuItems = menuItems.Where(x => x.Id == "UF");

            foreach (var menuItem in menuItems)
            {

                string qString = string.Empty;

                qString = $"api/v1/sv";
                qString += $"/ssd";

                qString += $"/{menuItem.Id}";
                var level1Items =
                    JsonConvert.DeserializeObject<IEnumerable<MenuItem>>(
                        _savedQueryService.GetService(serverAddress1 + qString));
                level1Items = GetReduceList<MenuItem>(level1Items.ToList());
                foreach (var level1Item in level1Items)
                {
                    var level1qString = qString + $"/{level1Item.Id}";
                    var level2Items =
                        JsonConvert.DeserializeObject<IEnumerable<MenuItem>>(
                            _savedQueryService.GetService(serverAddress1 + level1qString));
                    level2Items = GetReduceList<MenuItem>(level2Items.ToList());
                    foreach (var level2Item in level2Items)
                    {
                        var level2qString = level1qString + $"/{level2Item.Id}";
                       
                        var level2Result = _savedQueryService.GetService(serverAddress1 + level2qString);

                        try
                        {
                            var level3Items = JsonConvert.DeserializeObject<IEnumerable<MenuItem>>(level2Result);
                            level3Items = GetReduceList<MenuItem>(level3Items.ToList());
                            CompareApi(level3Items, level2qString, compareResultModelList);
                        }
                        catch (JsonSerializationException)
                        {
                            CompareApi(level2Items, level1qString, compareResultModelList);
                        }
                    }
                }
            }

            fileRepo.DeleteFile(compareResultFile);
            fileRepo.SaveToFile(compareResultModelList, compareResultFile);
           
            var resultFile = fileRepo.ReadFromFile(compareResultFile);
        }

        private List<CompareResultModel> CompareApi(IEnumerable<MenuItem> level3Items, string level2qString, List<CompareResultModel> compareResultModelList)
        {
            var serverAddress1 = _appSettingsHandler.ReadSetting("WebApiAddress1");
            // get url for api site 2
            var serverAddress2 = _appSettingsHandler.ReadSetting("WebApiAddress2");
            var resultFolder1 = _appSettingsHandler.ReadSetting("ResultFolder1") + "/Api/";
            var resultFolder2 = _appSettingsHandler.ReadSetting("ResultFolder2") + "/Api/";
            var fileRepo = new FileCompareRepo();

            foreach (var level3Item in level3Items)
            {
                var lev3qString = level2qString + $"/{level3Item.Id}";

                var queryResult1 = _savedQueryService.GetService(serverAddress1 + lev3qString);
                var queryResult2 = _savedQueryService.GetService(serverAddress2 + lev3qString);

                MetaTable metaTableResult;

                if (!string.IsNullOrEmpty(queryResult1) && !string.IsNullOrEmpty(queryResult2))
                {
                    metaTableResult = JsonConvert.DeserializeObject<MetaTable>(queryResult1);

                    var compareResultModel = new CompareResultModel {SavedQuery = level3Item.Id};

                    //var outputFormats = Enum.GetValues(typeof(OutputFormatApi)).Cast<OutputFormatApi>();

                    var outputFormats = Enum.GetValues(typeof(OutputFormat)).Cast<OutputFormat>().Where( x => x == OutputFormat.px || x == OutputFormat.xlsx || x == OutputFormat.csv || x == OutputFormat.json);


                    fileRepo.CreateFolder($"{resultFolder1}/{level3Item.Id}");
                    fileRepo.CreateFolder($"{resultFolder2}/{level3Item.Id}");

                    foreach (var outputFormat in outputFormats)
                    {
                        var tableQuery = MapToTableQuery(metaTableResult, outputFormat.ToString());

                          bool? result;


                        if (outputFormat == OutputFormat.xlsx)
                        {
                            bool res1;
                            bool res2;

                            res1 = _savedQueryService.PostAndSaveAsFile($"{serverAddress1}{lev3qString}",
                                $"{level3Item.Id}_{outputFormat}",
                                "xlsx", $"{resultFolder1}\\{level3Item.Id}\\"
                                ,tableQuery);

                            res2 = _savedQueryService.PostAndSaveAsFile($"{serverAddress1}{lev3qString}",
                                $"{level3Item.Id}_{outputFormat}",
                                "xlsx", $"{resultFolder2}\\{level3Item.Id}\\",
                                tableQuery);

                            Thread.Sleep(5000);

                            if (res1 && res2)
                            {
                                var resultList1 =
                                    _excelComparer.ReadExcelFile(
                                        $@"{resultFolder1}\{level3Item.Id}\{level3Item.Id}_{outputFormat}.xlsx");
                                var resultList2 =
                                    _excelComparer.ReadExcelFile(
                                        $@"{resultFolder2}\{level3Item.Id}\{level3Item.Id}_{outputFormat}.xlsx");
                                result = CompareArrayLists(resultList1, resultList2);
                            }
                            else
                            {
                                result = null;
                            }
                        }
                        else
                        {
                            var res1 = _savedQueryService.PostService($"{serverAddress1 + lev3qString}", tableQuery);
                            
                            var res2 = _savedQueryService.PostService($"{serverAddress2 + lev3qString}", tableQuery);

                            Thread.Sleep(1000);

                            if (res1 != null && res2 != null)
                            {
                                _savedQueryService.SaveToFile(res1, level3Item.Id, outputFormat.ToString(),
                                    $"{resultFolder1}\\{level3Item.Id}\\");
                                _savedQueryService.SaveToFile(res2, level3Item.Id, outputFormat.ToString(),
                                    $"{resultFolder2}\\{level3Item.Id}\\");
                                result = CompareSavedQueryResults(
                                    $@"{resultFolder1}/{level3Item.Id}/{level3Item.Id}_{outputFormat}.txt",
                                    $@"{resultFolder2}/{level3Item.Id}/{level3Item.Id}_{outputFormat}.txt");

                            }
                            else
                            {
                                result = null;
                            }

                            
                       }
                        compareResultModel.UpdateModel(outputFormat, result);
                    }
                    compareResultModelList.Add(compareResultModel);
                }
            }
            return compareResultModelList;
        }


        public TableQuery MapToTableQuery(MetaTable metaTable, string format)
        {
            var tableQuery = new TableQuery();
            var queryList = new List<Query>();

            foreach (var metaTableVariable in metaTable.Variables)
            {
                var query = new Query()
                {
                    Code = metaTableVariable.Code,
                    Selection = new QuerySelection()
                    {
                        Filter = "item",
                        // reduce this list
                        Values = GetReduceList<string>(metaTableVariable.Values.ToList()).ToArray()
                        //Values = metaTableVariable.Values

                    },
                };
                queryList.Add(query);
            }

            tableQuery.Query = queryList.ToArray();

            QueryResponse response = new QueryResponse();
            response.Format = format;
            tableQuery.Response = response;

            return tableQuery;
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

        public List<CompareResultModel> GetApiResults()
        {
            var compareResultFile = _appSettingsHandler.ReadSetting("CompareApiResultFile");
            var fileRepo = new FileCompareRepo();
            return fileRepo.ReadFromFile(compareResultFile);
        }

        public List<SavedQueryMetaCompareResultModel> GetSavedQueryResults()
        {
            var compareResultFile = _appSettingsHandler.ReadSetting("CompareSavedQueryResultFile");
            var fileRepo = new FileCompareRepo();
            return fileRepo.ReadFromSaveCompareResultModels(compareResultFile);
        }


    }

}
