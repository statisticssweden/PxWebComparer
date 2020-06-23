using System;
using System.Collections.Generic;
using System.IO;

namespace PxWebComparer.Repo
{
    public  class SavedQueryFileFormatRepo : ISavedQueryFileFormatRepo
    {

        public IEnumerable<string> GetSavedQueryFileFormat(string path)
        {
            string line;
            using (var reader = File.OpenText( path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
