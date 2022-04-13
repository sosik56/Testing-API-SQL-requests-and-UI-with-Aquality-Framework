using Newtonsoft.Json;

namespace task2API.Models
{
    public class Post
    {
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
