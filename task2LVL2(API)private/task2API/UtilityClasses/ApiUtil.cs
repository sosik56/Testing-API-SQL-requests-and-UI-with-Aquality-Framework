using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace task2API.UtilityClasses
{
    public static class ApiUtil
    {
        public static HttpResponseMessage GetRequest(string url, params string[] values)
        {
            StringBuilder stringBuilder = new StringBuilder(url);
            stringBuilder.AppendJoin("/", values);
            Uri endpoint = new Uri(stringBuilder.ToString());

            using (var client = new HttpClient())
            {
                HttpResponseMessage result = client.GetAsync(endpoint).Result;
                return result;
            }
        }

        public static HttpResponseMessage PostRequest<T>(T model, string url, params string[] values)
        {
            StringBuilder stringBuilder = new StringBuilder(url);
            stringBuilder.AppendJoin("/", values);
            Uri endpoint = new Uri(stringBuilder.ToString());

            string newModelJson = JsonConvert.SerializeObject(model);
            var payload = new StringContent(newModelJson, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                HttpResponseMessage result = client.PostAsync(endpoint, payload).Result;
                return result;
            }
        }
    }
}
