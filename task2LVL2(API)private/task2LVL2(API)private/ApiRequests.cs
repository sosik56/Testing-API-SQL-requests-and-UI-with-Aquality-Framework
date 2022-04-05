using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using task2LVL2_API_private.Models;

namespace task2LVL2_API_private
{
   public static class ApiRequests
    {
        public static ContentRespons GetRequest(string url, params string[] values)
        {
            StringBuilder stringBuilder = new StringBuilder(url);
            stringBuilder.AppendJoin("/", values);
            Uri endpoint = new Uri(stringBuilder.ToString());

            using (var client = new HttpClient())
            {
                var result = client.GetAsync(endpoint).Result;
                var statusCode = Convert.ToInt32(result.StatusCode);
                var IsJson = result.Content.Headers.ContentType.MediaType;                
                var jsonAnswer = result.Content.ReadAsStringAsync().Result;
                return new ContentRespons(jsonAnswer, IsJson, statusCode);                
            } 
        }        

        public static ContentRespons PostRequest<T>(T model, string url, params string[] values)
        {
            StringBuilder stringBuilder = new StringBuilder(url);
            stringBuilder.AppendJoin("/", values);
            Uri endpoint = new Uri(stringBuilder.ToString());

            string newModelJson = JsonConvert.SerializeObject(model);
            var payload = new StringContent(newModelJson, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {                
                var result = client.PostAsync(endpoint, payload).Result;
                var statusCode = Convert.ToInt32(result.StatusCode);
                var IsJson = result.Content.Headers.ContentType.MediaType;
                var jsonAnswer = result.Content.ReadAsStringAsync().Result;

                return new ContentRespons(jsonAnswer, IsJson, statusCode);
            }
        }
    }
}
