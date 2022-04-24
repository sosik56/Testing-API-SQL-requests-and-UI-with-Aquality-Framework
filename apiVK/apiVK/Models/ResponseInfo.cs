using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace apiVK.Models
{
    public class ResponseInfo
    {
        public Response Response { get; set; }
    }

    public class UsersItem
    {        
        public int Uid { get; set; }

        [JsonPropertyName("copied")]
        public int Copied { get; set; }
    }

    public class Response
    {
        public int Album_id { get; set; }
       
        public string Upload_url { get; set; }
       
        public int User_id { get; set; }

        public int Post_id { get; set; }

        public int Server { get; set; }
        
        public string Photo { get; set; }
        
        public int Comment_id { get; set; }

        public string[] Parents_stack { get; set; }

        public string Hash { get; set; }

        [JsonPropertyName("id")]
        public int PhotoId { get; set; }

        
        public int Count { get; set; }

        
        public List<UsersItem> Users { get; set; }
    }   
   
}
