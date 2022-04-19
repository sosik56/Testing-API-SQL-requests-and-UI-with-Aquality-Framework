using System.Collections.Generic;
using System.IO;
using System.Text;

namespace workWithDb.UtilityClasses
{
    public static  class UtilityClass
    {
        private const string data = "workWithDb.Resources.data.json";
        private const string sqlRequest = "workWithDb.Resources.sqlRequest.json";

        public static string ReturnDataValue(string key)
        {
            Dictionary<string, string> keyValuePairs = DeSerializeJSON.DeSerializeFileReflection<Dictionary<string, string>>(data);
            return keyValuePairs[key];
        }

        public static string ReturnSqlRequestValue(string key)
        {
            Dictionary<string, string> keyValuePairs = DeSerializeJSON.DeSerializeFileReflection<Dictionary<string, string>>(sqlRequest);
            return keyValuePairs[key];
        }

        public static void WriteToFile(StringBuilder respons, string fileName)
        {
            File.WriteAllText(fileName, respons.ToString());
        }

    }
}
