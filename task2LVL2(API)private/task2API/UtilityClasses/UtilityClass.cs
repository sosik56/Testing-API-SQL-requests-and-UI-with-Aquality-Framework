using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using task2API.Models;
using task2API.UtilityClasses;

namespace task2API
{
    public static class UtilityClass
    {
        private const string data = "task2API.Resourses.TestData.json";

        public static string ReturnValue(string key)
        {
            string text;
            var assembly = typeof(Tests).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(data);
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            Dictionary<string, string> keyValuePairs = DeSerializeClass.DeserializeObject<Dictionary<string, string>>(text);
            return keyValuePairs[key];
        }

        public static bool IsSortedBy(string bySort, string content)
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
