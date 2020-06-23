using System;
using System.Configuration;

namespace PxWebComparer.Business
{
    public class AppSettingsHandler : IAppSettingsHandler
    {

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
    }
}
