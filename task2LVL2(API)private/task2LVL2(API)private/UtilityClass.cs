using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using task2LVL2_API_private.Models;

namespace task2LVL2_API_private
{
    public static class UtilityClass
    {
        public static string data = "task2LVL2_API_private.Resourses.TestData.json";

        public static bool IsSortedBy(string bySort , string content)
        {           
            JArray jsonArray = JArray.Parse(content);

            for (int index = 0; index < jsonArray.Count - 1; index++)
            {
                int id = Convert.ToInt32(jsonArray[index][bySort]);
                int idNext = Convert.ToInt32(jsonArray[index].Next[bySort]);
                if (idNext < id)
                {
                    return false;
                }
            }
            return true;
        }

        public static T GetObjectFromArrayJson<T>(string content, int index)
        {            
            JArray jsonArray = JArray.Parse(content);
            var answer = jsonArray[index].ToObject<T>();
            
            return answer;
        }        

        public static T DeserializeObject<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);            
        }

        public static string ReturnValue(string path, string key)
        {
            string text;
            var assembly = typeof(Tests).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(path);
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            Dictionary<string, string> keyValuePairs = DeserializeObject<Dictionary<string, string>>(text);
            return keyValuePairs[key];
        }               

        public static Post CreatRandomPostWithUserId(int id)
        {
            return new Post
            {
                UserId = id,
                Body = Guid.NewGuid().ToString(),
                Title = Guid.NewGuid().ToString()
            };
        }        
    }
}
