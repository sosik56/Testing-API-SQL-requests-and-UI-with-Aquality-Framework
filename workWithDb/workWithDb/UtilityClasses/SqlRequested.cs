using System.Text;
using MySql.Data.MySqlClient;
using System.IO;

namespace workWithDb.UtilityClasses
{
    public static class SqlRequested
    {
        public static void ExecuteSqlRequestFromDB(string host, string dbname, string user, string password, string sqlRequest, string fileName)
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

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("***********************************");
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        answer.Append(reader.GetName(i) + "|");
                        answer.Append("{0, -20}|");
                    }
                    sw.WriteLine(answer);


                    while (reader.Read())
                    {
                        string str = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            str += reader[i].ToString() + "|";
                        }
                        sw.WriteLine("{0, -20}|", str);                       
                        str = null;
                    }
                }
            }
        }
    }
}
