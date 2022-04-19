using System.Text;
using MySql.Data.MySqlClient;
using System;

namespace workWithDb.UtilityClasses
{
    public static class SqlRequested
    {
        public static StringBuilder ExecuteSqlRequestFromDB(string host, string dbname, string user, string password, string sqlRequest)
        {
            string connectionString = $"server={host};" +
                                      $"user={user};" +
                                      $"database={dbname};" +
                                      $"password={password}";

            using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
            {
                sqlConn.Open();
                MySqlCommand sqlComm = new MySqlCommand(sqlRequest, sqlConn);
                MySqlDataReader reader = sqlComm.ExecuteReader();
                
                StringBuilder answer = new StringBuilder();           
                               
                    string header = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        header += String.Format("{0,-130}", reader.GetName(i));                                              
                    }                   
                    answer.AppendLine(header);
                    answer.AppendLine();

                    while (reader.Read())
                    {
                        string str = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            str += String.Format("{0,-130}", reader[i].ToString());
                        }                        
                        answer.AppendLine(str);
                        str = null;
                    }
                    
                    return answer;                
            }
        }
    }
}
