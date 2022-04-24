using apiVK.BaseClasses;
using apiVK.Models;
using apiVK.UtilityClasses;
using NUnit.Framework;
using apiVK.PageObjects;
using System;

namespace apiVK
{
    public class VkApiTest:BaseTest
    {
        private VkSignRegistrPage _vkSignAndRegisterPage = new VkSignRegistrPage();
        private AutorizationPage _autorizationPage = new AutorizationPage();
        private SideBar _sideBar = new SideBar();
        private UserWall _userWall = new UserWall();

        private User user = new User(UtilityClass.ReturnValue("loginUser"),
                                     UtilityClass.ReturnValue("userPass"),
                                     UtilityClass.ReturnValue("userToken"),
                                     UtilityClass.ReturnValue("userName"),
                                     UtilityClass.ReturnValue("userSecondName"),
                                     UtilityClass.ReturnValue("id"));

        [Test]
        public void Test1()
        {
            //Authorization
            Assert.IsTrue(_vkSignAndRegisterPage.State.IsDisplayed, "main page is not open");
            _vkSignAndRegisterPage.ClickSignInButton();
            _autorizationPage.AutorizationUser(user);
            _sideBar.ClickMyPageButton();

            //Post text on wall
            string randomText = UtilityClass.GetRandomGuid();
            var content = VkApiUtils.PostTextOnWall(randomText, user.Id, user.Token);           
            ResponseInfo response  = DeSerializeClass.DeserializeObject<ResponseInfo>(content.Content);
            int post_id = response.Response.Post_id; //post_id for change post in future                       
            Assert.IsTrue(_userWall.IsPostByTextAndUserIdHere(randomText, user.Id), "There is no such post with this text or user");
            
            //Edit post
            string randomText2 = UtilityClass.GetRandomGuid();
            var contentAfterEdit = VkApiUtils.EditTextAndImagePostOnTheWall(randomText2, user.Id, post_id.ToString() , user.Token,
                UtilityClass.ReturnValue("imageName"));             
            Assert.IsTrue(_userWall.IsPostByTextUserIdAndContentIdHere(randomText2, user.Id,contentAfterEdit.contentId),
                "There is no such post with this text and content or user");

            //Create Post
            var responseAfterPost = VkApiUtils.CreateTextCommetOnTheWall(randomText2, user.Id, user.Token, post_id.ToString());
            ResponseInfo commentInfo = DeSerializeClass.DeserializeObject<ResponseInfo>(responseAfterPost.Content);
            var commentId = commentInfo.Response.Comment_id;
            Assert.IsTrue(_userWall.IsCommentUnderPostByIdHere(user.Id, post_id.ToString(), user.Id, commentInfo.Response.Comment_id.ToString()),
                "There is no such comment with this user");

            //Like Post
            _userWall.ClickLikeButtonOnPost(post_id.ToString(), user.Id);
            var infoAboutLikes = VkApiUtils.GetLikesInfoFromPost(user.Id, post_id.ToString(), user.Token);
            ResponseInfo likeInfo = DeSerializeClass.DeserializeObject<ResponseInfo>(infoAboutLikes.Content);
            Assert.IsTrue(UtilityClass.IsUserExistFromListByUid(likeInfo.Response.Users, Convert.ToInt32(user.Id)), "User dont likes this psot");

            //Delet Post
            VkApiUtils.DeletPostFromWall(user.Id, post_id.ToString(), user.Token);            
            Assert.IsFalse(_userWall.IsPostDeletedByUserAndPostId(user.Id, post_id.ToString()), "There is  such post");            
        }       
    }
}