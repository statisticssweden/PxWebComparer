namespace PxWebComparer.Business
{
    public interface ICompareHandler
    {
        void Compare();

        bool CompareSavedQueryResults(string file1, string file2);

     

    }
}
