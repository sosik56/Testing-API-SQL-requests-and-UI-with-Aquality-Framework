using System.Net.Http;
using task2API.Models;

namespace task2API.UtilityClasses
{
    public static class ApplicationApi
    {
        public static ContentRespons GetAllUsers()
        {
            var result = ApiUtil.GetRequest(UtilityClass.ReturnValue("url"),
                                            UtilityClass.ReturnValue("usersEnd"));

            return GetContentRespons(result);
        }

        public static ContentRespons GetUserById(string id)
        {
            var result = ApiUtil.GetRequest(UtilityClass.ReturnValue("url"),
                                            UtilityClass.ReturnValue("usersEnd"),
                                            id);

            return GetContentRespons(result);
        }

        public static ContentRespons GetPostById(string id)
        {
            var result = ApiUtil.GetRequest(UtilityClass.ReturnValue("url"),
                                            UtilityClass.ReturnValue("postsEnd"),
                                            id);

            return GetContentRespons(result);
        }

        public static ContentRespons GetAllPosts()
        {
            var result = ApiUtil.GetRequest(UtilityClass.ReturnValue("url"),
                                            UtilityClass.ReturnValue("postsEnd"));

            return GetContentRespons(result);
        }

        public static ContentRespons CreateThePost(Post newPost)
        {
            var result = ApiUtil.PostRequest(newPost,
                                             UtilityClass.ReturnValue("url"),
                                             UtilityClass.ReturnValue("postsEnd"));

            return GetContentRespons(result);
        }

        public static ContentRespons GetContentRespons(HttpResponseMessage message)
        {
            var statusCode = message.StatusCode;
            var IsJson = message.Content.Headers.ContentType.MediaType;
            var jsonAnswer = message.Content.ReadAsStringAsync().Result;
            return new ContentRespons(jsonAnswer, IsJson, statusCode);
        }
    }
}
