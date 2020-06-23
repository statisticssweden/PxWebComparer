using System;
using System.Collections.Generic;
using System.Text;

namespace PxWebComparer.Business
{
    public interface IAppSettingsHandler
    {
        string ReadSetting(string key);
    }
}
