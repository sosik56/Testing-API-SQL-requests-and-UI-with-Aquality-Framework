using System.Text;

namespace workWithDb.UtilityClasses
{
    public static class DBAplication
    {
        public static StringBuilder ExecuteFirstRequest()
        {
            return SqlRequested.ExecuteSqlRequestFromDB(UtilityClass.ReturnDataValue("server"),
                                                                         UtilityClass.ReturnDataValue("database"),
                                                                         UtilityClass.ReturnDataValue("user"),
                                                                         UtilityClass.ReturnDataValue("password"),
                                                                         UtilityClass.ReturnSqlRequestValue("sqlRequest1"));
        }

        public static StringBuilder ExecuteSecondRequest()
        {
            return SqlRequested.ExecuteSqlRequestFromDB(UtilityClass.ReturnDataValue("server"),
                                                                         UtilityClass.ReturnDataValue("database"),
                                                                         UtilityClass.ReturnDataValue("user"),
                                                                         UtilityClass.ReturnDataValue("password"),
                                                                         UtilityClass.ReturnSqlRequestValue("sqlRequest2"));
        }

        public static StringBuilder ExecuteThirdRequest()
        {
            return SqlRequested.ExecuteSqlRequestFromDB(UtilityClass.ReturnDataValue("server"),
                                                                         UtilityClass.ReturnDataValue("database"),
                                                                         UtilityClass.ReturnDataValue("user"),
                                                                         UtilityClass.ReturnDataValue("password"),
                                                                         UtilityClass.ReturnSqlRequestValue("sqlRequest3"));
        }
        public static StringBuilder ExecuteFourRequest()
        {
            return SqlRequested.ExecuteSqlRequestFromDB(UtilityClass.ReturnDataValue("server"),
                                                                             UtilityClass.ReturnDataValue("database"),
                                                                             UtilityClass.ReturnDataValue("user"),
                                                                             UtilityClass.ReturnDataValue("password"),
                                                                             UtilityClass.ReturnSqlRequestValue("sqlRequest4"));
        }

        public static void WriteToFile(StringBuilder reader, string fileName)
        {
            UtilityClass.WriteToFile(reader,fileName);
        } 
    }
}
