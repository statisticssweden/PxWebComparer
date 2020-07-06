using System;
using System.Collections.Generic;
using System.Text;

namespace PxWebComparer.Repo
{
    public interface IDatabaseRepo
    {
        string GetSavedQueryById(int id);

    }
}
