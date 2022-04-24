using System.Net;

namespace apiVK.Models
{
    public class ContentRespons
    {
        public string Body { get; set; }
        public string MediaType { get; set; }
        public HttpStatusCode StatuseCode { get; set; }

        public ContentRespons(string body, string mediaType, HttpStatusCode statusCode)
        {
            Body = body;
            MediaType = mediaType;
            StatuseCode = statusCode;
        }
    }
}
