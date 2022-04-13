using System.Collections.Generic;

namespace workWithDb.UtilityClasses
{
    public static  class UtilityClass
    {
        public static string data = "workWithDb.Resources.data.json";
        
        public static string ReturnValue(string fileName, string key)
        {
            Dictionary<string, string> keyValuePairs = DeSerializeJSON.DeSerializeFileReflection<Dictionary<string, string>>(fileName);
            return keyValuePairs[key];
        }
    }
}
