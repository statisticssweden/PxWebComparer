using System.Collections;
using System.Collections.Generic;
using PxWebComparer.Model;

namespace PxWebComparer.Business
{
    public interface ICompareHandler
    {
        void Compare();
        void CompareSavedQueryMetaDatabase();
        void CompareSavedQueryMetaPxsq();
        string SavedQueryString(SavedQuery sq);
        bool CompareSavedQueryResults(string file1, string file2);
        List<T> GetReduceList<T>(List<T> list);
        void CompareApi(string language, string database);
        TableQuery MapToTableQuery(MetaTable metaTable, string format);
        List<CompareResultModel> GetResults();
        public List<CompareResultApiModel> GetApiResults();
        public List<SavedQueryMetaCompareResultModel> GetSavedQueryResults();
        bool CompareArrayLists(ArrayList arrayList1, ArrayList arrayList2);
        List<CompareResultApiModel> CompareApi(IEnumerable<MenuItem> level3Items, string level2qString,
            List<CompareResultApiModel> compareResultModelList);

    }
}
