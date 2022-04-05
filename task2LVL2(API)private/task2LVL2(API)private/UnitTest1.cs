using NUnit.Framework;
using task2LVL2_API_private.Models;

namespace task2LVL2_API_private
{
    public class Tests
    {        
        [Test]
        public void Test1()
        {           
            ContentRespons getPosts = ApiRequests.GetRequest(UtilityClass.ReturnValue(UtilityClass.data, "FirstRequst"));
            Assert.AreEqual(200, getPosts.StatuseCode, "Status code is not apropriate");
            Assert.True(getPosts.MediaType.Contains("json"),"Respons body isn't JSON");
            Assert.True(UtilityClass.IsSortedBy("id", getPosts.Body),"Isn't sorted by id");


            ContentRespons getPosts99 = ApiRequests.GetRequest(UtilityClass.ReturnValue(UtilityClass.data, "SecondRequest"));
            Assert.AreEqual(200, getPosts99.StatuseCode, "Status code is not apropriate");
            string jsonStringFromSecondReq = getPosts99.Body;
            var objectPost99 = UtilityClass.DeserializeObject<Post>(getPosts99.Body);
            var dataPost99 = UtilityClass.DeserializeObject<Post>(UtilityClass.ReturnValue(UtilityClass.data, "getPostId1"));
            
            Assert.AreEqual(dataPost99.UserId, objectPost99.UserId, "UserId is not apropriate");
            Assert.AreEqual(dataPost99.Id, objectPost99.Id, "Id is not apropriate");
            Assert.True(objectPost99.Body.Length > 0 && objectPost99.Title.Length > 0, "Body length is 0");


            ContentRespons getPosts150 = ApiRequests.GetRequest(UtilityClass.ReturnValue(UtilityClass.data, "ThirdRequest"));            
            Assert.AreEqual(404, getPosts150.StatuseCode, "Status code is not apropriate");
            Assert.True(getPosts150.Body.Length == 2, "Body length is not empty");


            Post postWithUserId1 = UtilityClass.CreatRandomPostWithUserId(1);
            ContentRespons postThePostsUserID = ApiRequests.
                PostRequest(postWithUserId1,(UtilityClass.ReturnValue(UtilityClass.data, "FourRequest")));
            Post recivingPostUserId1 = UtilityClass.DeserializeObject<Post>(postThePostsUserID.Body);
            Assert.AreEqual(postWithUserId1.UserId, recivingPostUserId1.UserId, "UserId Not the same");
            Assert.AreEqual(postWithUserId1.Body, recivingPostUserId1.Body, "Body Not the same");
            Assert.AreEqual(postWithUserId1.Title, recivingPostUserId1.Title, "Title Not the same");
            Assert.True(recivingPostUserId1.Id > 0, "There is no id");

            ContentRespons getUsers = ApiRequests.GetRequest(UtilityClass.ReturnValue(UtilityClass.data, "FiveRequest"));
            Assert.True(getUsers.StatuseCode == 200, "Status code is not apropriet");
            Assert.True(getUsers.MediaType.Contains("json"), "Respons body is not a json");
            
            User userFive = UtilityClass.GetObjectFromArrayJson<User>(getUsers.Body, 4);
            User userFiveFromData = UtilityClass.DeserializeObject<User>(UtilityClass.ReturnValue(UtilityClass.data, "getUsers5"));
            Assert.True(userFive.Equals(userFiveFromData), "Users are different");
            

            ContentRespons getUsers5 = ApiRequests.GetRequest(UtilityClass.ReturnValue(UtilityClass.data, "SixRequest"));
            User user5FromGetUser5 = UtilityClass.DeserializeObject<User>(getUsers5.Body);
            Assert.True(userFive.Equals(user5FromGetUser5),"Users are not Equals");                        
        }
    }
}