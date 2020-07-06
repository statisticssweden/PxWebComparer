using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using PxWebComparer.Business;

namespace PxWebComparer.Repo
{
    public class DatabaseRepo : IDatabaseRepo
    {



        private readonly AppSettingsHandler _appSettingsHandler = new AppSettingsHandler();

        public string GetSavedQueryById(int QueryId)
        {

            string resultString = string.Empty;

            try

            {

                var connectionString = _appSettingsHandler.ReadSetting("SavedQueryConnectionString");
                //string connectionString  = ConfigurationManager.ConnectionStrings["SavedQueryConnectionString"].ConnectionString;

                //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                //{
                //    DataSource = "<your_server.database.windows.net>",
                //    UserID = "<your_username>",
                //    Password = "<your_password>",
                //    InitialCatalog = "<your_database>"
                //};

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    StringBuilder sb = new StringBuilder();

                    sb.Append("SELECT * from SavedQueryMeta ");
                    sb.Append($"WHERE [QueryId] = {QueryId}");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                resultString = resultString + reader.GetString(17);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return resultString;
        }
    }
}