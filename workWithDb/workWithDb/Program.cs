using workWithDb.UtilityClasses;

namespace workWithDb
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlRequested.ExecuteSqlRequestFromDB(UtilityClass.ReturnValue(UtilityClass.data, "server"), 
                                                UtilityClass.ReturnValue(UtilityClass.data, "database"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "user"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "password"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "sqlRequest1"),
                                                "firstSqlRequest.txt");

            SqlRequested.ExecuteSqlRequestFromDB(UtilityClass.ReturnValue(UtilityClass.data, "server"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "database"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "user"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "password"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "sqlRequest2"),
                                                "secondSqlRequst.txt");

            SqlRequested.ExecuteSqlRequestFromDB(UtilityClass.ReturnValue(UtilityClass.data, "server"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "database"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "user"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "password"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "sqlRequest3"),
                                                "thirdSqlRequst.txt");

            SqlRequested.ExecuteSqlRequestFromDB(UtilityClass.ReturnValue(UtilityClass.data, "server"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "database"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "user"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "password"),
                                                UtilityClass.ReturnValue(UtilityClass.data, "sqlRequest4"),
                                                "fourSqlRequst.txt");
        }
    }
}
