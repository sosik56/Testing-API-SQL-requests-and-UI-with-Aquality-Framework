using apiVK.Models;
using RestSharp;

namespace apiVK.UtilityClasses
{
    public static class VkApiUtils
    {
        private const string _VKAPIURL = "https://api.vk.com/method/";
        private const string _VERSION = "5.131";
        
        public static RestResponse DeletPostFromWall(string owner_id, string post_id, string token)
        {
            string endpoint = $"{_VKAPIURL}wall.delete?owner_id={owner_id}&post_id={post_id}&access_token={token}&v={_VERSION}";
            return ApiUtil.RestGetRequest(endpoint);
        }

        public static RestResponse GetLikesInfoFromPost(string owner_id, string post_id, string token)
        {
            string endpoint = $"{_VKAPIURL}wall.getLikes?owner_id={owner_id}&post_id={post_id}&access_token={token}&v={_VERSION}";
            return ApiUtil.RestGetRequest(endpoint);
        }

        public static RestResponse CreateTextCommetOnTheWall(string text, string ownerId , string token, string postId)
        {
            string endpoint = $"{_VKAPIURL}wall.createComment?owner_id={ownerId}&message={text}&post_id={postId}&access_token={token}&v={_VERSION}";
            return ApiUtil.RestGetRequest(endpoint);
        }

        public static RestResponse PostTextOnWall(string text,string id,string token, params string[] values)
        {
            string endpoint = $"{_VKAPIURL}wall.post?owner_id={id}&message={text}&access_token={token}&v={_VERSION}";
            return ApiUtil.RestGetRequest(endpoint);            
        }

        public static (string contentId,RestResponse response) EditTextAndImagePostOnTheWall
            (string text, string userId , string postId, string token,string imagePath)            
        {
            var uploadUrl = GetWallPhotoUploadServer(userId, token);
            var infoAboutImage = UploadMediaTypeOnServer(uploadUrl, imagePath,"photo");
            var fileID = SaveWallPhotoAndGetId(infoAboutImage.Photo,infoAboutImage.Server.ToString(),infoAboutImage.Hash, userId, token);
            
            var response = ApiUtil.RestPostRequest($"{_VKAPIURL}wall.edit?owner_id={userId}&post_id={postId}&attachments=photo{userId}_{fileID}" +
                $"&message={text}&access_" +
                $"token={token}&v={_VERSION}");

            return ($"/photo{userId}_{fileID}", response);
        }

        public static string GetWallPhotoUploadServer(string id, string token)
        {            
            var resualt = ApiUtil.RestGetRequest($"{_VKAPIURL}photos.getWallUploadServer?user_id={id}&access_token={token}&v={_VERSION}");
            ResponseInfo response = DeSerializeClass.DeserializeObject<ResponseInfo>(resualt.Content);
            return response.Response.Upload_url;           
        }

        public static Response UploadMediaTypeOnServer(string uploadUrl, string imagePath, string mediaType)
        {
            var result = ApiUtil.RestPostWithFileRequest(uploadUrl,imagePath,mediaType);             
            return DeSerializeClass.DeserializeObject<Response>(result.Content);
        }

        public static string SaveWallPhotoAndGetId(string photo, string server, string hash, string userId, string token)
        {            
            var result = ApiUtil.RestPostRequest($"{_VKAPIURL}photos.saveWallPhoto?user_id={userId}&photo={photo}&server={server}&hash={hash}&access_" +
                $"token={token}&v={_VERSION}");
            
            return  DeSerializeClass.GetValueFromJsonString(result.Content, "response[0].id");                     
        } 
    }
}
