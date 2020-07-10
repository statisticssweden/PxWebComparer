using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PxWebComparer.Business;

namespace PxWebComparer.Repo
{
    public class DatabaseRepo : IDatabaseRepo
    {
        private readonly AppSettingsHandler _appSettingsHandler = new AppSettingsHandler();

        public string GetSavedQueryById(string QueryId,string connectionString)
        {

            string resultString = string.Empty;
            {

                //var connectionString = _appSettingsHandler.ReadSetting("SavedQueryConnectionString");
                
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
            
            return resultString;
        }

        public List<string> GetSavedQueries(string connectionString, int topRowCount = 0 )
        {
            string resultString = string.Empty;
            List<string> result = new List<string>();
            string top = String.Empty;


            if (topRowCount > 0)
                top = $" TOP {topRowCount}";

            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    StringBuilder sb = new StringBuilder();

                    sb.Append($"SELECT {top} QueryId from SavedQueryMeta ");
                    sb.Append($"ORDER BY QueryId DESC");
                    
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(Convert.ToString(reader["QueryId"]));
                            }
                        }
                    }
                }
            }
            
            return result;
        }
    }
}