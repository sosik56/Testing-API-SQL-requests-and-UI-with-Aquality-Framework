using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace task2API.UtilityClasses
{
    public static class DeSerializeClass
    {
        public static T DeserializeObject<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }

        public static T GetObjectFromArrayJson<T>(string content, int index)
        {
            JArray jsonArray = JArray.Parse(content);
            var answer = jsonArray[index].ToObject<T>();

            return answer;
        }
    }
}
