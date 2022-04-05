namespace task2LVL2_API_private.Models
{
    public class ContentRespons
    {
        public ContentRespons(string body, string mediaType, int statusCode)
        {
            Body = body;
            MediaType = mediaType;
            StatuseCode = statusCode;
        }

        public string Body { get; set; }
        public string MediaType { get; set; }
        public int StatuseCode { get; set; }
    }
}
