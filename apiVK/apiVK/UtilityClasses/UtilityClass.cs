using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using apiVK.Models;

namespace apiVK.UtilityClasses
{
    public static class UtilityClass
    {
        private const string data = "apiVK.Resources.TestData.json"; 

        public static string ReturnValue(string key)
        {
            string text;
            var assembly = typeof(VkApiTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(data);
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            Dictionary<string, string> keyValuePairs = DeSerializeClass.DeserializeObject<Dictionary<string, string>>(text);
            return keyValuePairs[key];
        }
        

        public static string GetRandomGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static bool IsUserExistFromListByUid(List<UsersItem> list, int uid)
        {
            UsersItem found = list.Find(item => item.Uid == uid);
            return found.Uid != 0;            
        }
    }

}
