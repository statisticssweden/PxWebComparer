using System.Collections.Generic;
using PxWebComparer.Model;

namespace PxWebComparer.Business
{
    public interface ICompareHandler
    {
        void Compare();
        void CompareSavedQueryMetaDatabase();
        void CompareSavedQueryMetaPxsq();
        bool CompareSavedQueryResults(string file1, string file2);
        void CompareApi();
        //ableQuery GetTableQuery();
        TableQuery MapToTableQuery(MetaTable metaTable, string format);
        List<CompareResultModel> GetResults();
       // void Compare
    }
}
