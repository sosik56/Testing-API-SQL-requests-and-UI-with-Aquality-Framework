using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace apiVK.UtilityClasses
{
    public static class DeSerializeClass
    {
        public static T DeserializeObject<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        } 

        public static string GetValueFromJsonString(string jsonStr, string key)
        {
           return JObject.Parse(jsonStr).SelectToken(key).ToString();          
        }        
    }
}
