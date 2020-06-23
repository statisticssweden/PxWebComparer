using System.Collections.Generic;

namespace PxWebComparer.Repo
{
    public interface ISavedQueryFileFormatRepo
    {
        IEnumerable<string> GetSavedQueryFileFormat(string path);
    }
}
