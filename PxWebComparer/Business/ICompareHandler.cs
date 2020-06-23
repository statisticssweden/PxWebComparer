using System.Collections.Generic;
using PxWebComparer.Model;

namespace PxWebComparer.Business
{
    public interface ICompareHandler
    {
        void Compare();

        bool CompareSavedQueryResults(string file1, string file2);

        List<CompareResultModel> GetResults();
    }
}
