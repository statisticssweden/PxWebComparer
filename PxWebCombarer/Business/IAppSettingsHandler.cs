using System;
using System.Collections.Generic;
using System.Text;

namespace PxWebComparer.Business
{
    public interface IAppSettingsHandler
    {
        void ReadAllSettings();
      
        string ReadSetting(string key);
        
        void AddUpdateAppSettings(string key, string value);


    }
}
