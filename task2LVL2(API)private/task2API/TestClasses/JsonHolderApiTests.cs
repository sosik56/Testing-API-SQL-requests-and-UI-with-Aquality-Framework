using System.Net;
using NUnit.Framework;
using task2API.Models;
using task2API.UtilityClasses;

namespace task2API
{
    public class Tests
    {   
        [Test]
        public void GetAndPostTest()
        {    
            
            ContentRespons getAllPosts = ApplicationApi.GetAllPosts();            
            Assert.AreEqual(HttpStatusCode.OK, getAllPosts.StatuseCode, "Status code is not apropriate");
            Assert.True(getAllPosts.MediaType.Contains("json"), "Respons body isn't JSON");
            Assert.True(UtilityClass.IsSortedBy("id", getAllPosts.Body), "Isn't sorted by id");


            ContentRespons getPostId99 = ApplicationApi.GetPostById("99");            
            Assert.AreEqual(HttpStatusCode.OK, getPostId99.StatuseCode, "Status code is not apropriate");            
            var objectPost99 = DeSerializeClass.DeserializeObject<Post>(getPostId99.Body);
            var dataPost99 = DeSerializeClass.DeserializeObject<Post>(UtilityClass.ReturnValue("getPostId1"));
            Assert.AreEqual(dataPost99.UserId, objectPost99.UserId, "UserId is not apropriate");
            Assert.AreEqual(dataPost99.Id, objectPost99.Id, "Id is not apropriate");
            Assert.True(objectPost99.Body.Length > 0 && objectPost99.Title.Length > 0, "Body length is 0");


            ContentRespons getPostId150 = ApplicationApi.GetPostById("150");            
            Assert.AreEqual(HttpStatusCode.NotFound, getPostId150.StatuseCode, "Status code is not apropriate");
            Assert.AreEqual(getPostId150.Body.Length, 2, "Body length is not empty");


            Post postWithUserId1 = UtilityClass.CreatRandomPostWithUserId(1);
            ContentRespons postThePostsUserID = ApplicationApi.CreateThePost(postWithUserId1);            
            Post recivingPostUserId1 = DeSerializeClass.DeserializeObject<Post>(postThePostsUserID.Body);
            Assert.AreEqual(HttpStatusCode.Created, postThePostsUserID.StatuseCode, "Status code is not apropriate");
            Assert.AreEqual(postWithUserId1.UserId, recivingPostUserId1.UserId, "UserId Not the same");
            Assert.AreEqual(postWithUserId1.Body, recivingPostUserId1.Body, "Body Not the same");
            Assert.AreEqual(postWithUserId1.Title, recivingPostUserId1.Title, "Title Not the same");
            Assert.True(recivingPostUserId1.Id > 0, "There is no id");


            ContentRespons getUsers = ApplicationApi.GetAllUsers();            
            Assert.AreEqual(getUsers.StatuseCode ,HttpStatusCode.OK, "Status code is not apropriet");
            Assert.True(getUsers.MediaType.Contains("json"), "Respons body is not a json");
            User userFive = DeSerializeClass.GetObjectFromArrayJson<User>(getUsers.Body, 4);
            User userFiveFromData = DeSerializeClass.DeserializeObject<User>(UtilityClass.ReturnValue("getUsers5"));           
            Assert.AreEqual(userFive, userFiveFromData, "Users are different");


            ContentRespons getUserID5 = ApplicationApi.GetUserById("5");            
            User user5FromGetUser5 = DeSerializeClass.DeserializeObject<User>(getUserID5.Body);            
            Assert.AreEqual(userFive, user5FromGetUser5, "Users are not Equals");
        }
    }
}