using System;
using System.Configuration;

namespace PxWebComparer.Business
{
    public class AppSettingsHandler : IAppSettingsHandler
    {

        public void ReadAllSettings()
        {
            throw new NotImplementedException();
        }

        public string ReadSetting(string key)
        {
           
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException e)
            {
                throw e;
            }
        }

        public void AddUpdateAppSettings(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
