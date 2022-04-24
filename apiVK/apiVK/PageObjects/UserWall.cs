using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace apiVK.PageObjects
{    
    public class UserWall:Form
    {        
        private IButton _likePost(string postId, string creatorId) =>
           AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//div[contains(@id,'{creatorId}_{postId}')]//div[@class='like_btns']" +
               $"//div[@data-reaction-set-id='reactions']"),
           "Button Like");

        private IButton _showNextCommentsByPostId(string postId) =>
            AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//a[contains(@onclick,'showNextReplies')][contains(@onclick,'{postId}')]"),
            "Button to next comments");

        private ILabel _userPostByUserIdAndText(string text, string userID) =>
            AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//div[contains(@id,'{userID}')]//div[contains(text(),'{text}')]"),
            "Label by text and userId");

        private ILink _userPostByUserIdTextAndContenId(string text, string userId, string contentId) =>
            AqualityServices.Get<IElementFactory>().GetLink(By.XPath($"//div[contains(@id,'{userId}')]" +
                $"//div[contains(text(),'{text}')]/following::a[contains(@href,'{contentId}')]"), "Link on content");

        private ILabel _commentUnderPostById (string creatorPostId, string postId, string creatorCommentId , string commentId) =>
            AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//div[contains(@id,'{creatorPostId}_{postId}')]" +
                 $"//div[@id='post{creatorCommentId}_{commentId}']"), "Lable Comment");
               
         private ILabel _userPostByUserIdAndPostId(string postId, string userID) =>
            AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//div[contains(@id,'{userID}_{postId}')]"),
            "Post by postId and userId");


        public UserWall() : base(By.XPath("//div[@id='page_body']//div[@id='profile']"),"User Wall") { }


        public bool IsPostDeletedByUserAndPostId(string userId,string postId)
        {
            return _userPostByUserIdAndPostId(postId, userId).State.WaitForNotExist();
        }

        public void ClickLikeButtonOnPost(string postId, string creatorId)
        {
            _likePost(postId, creatorId).Click();
        }

        public bool IsCommentUnderPostByIdHere(string creatorPostId, string postId, string creatorCommentId, string commentId)
        {
            if(!_commentUnderPostById(creatorPostId, postId, creatorCommentId, commentId).State.IsExist)
            {
                _showNextCommentsByPostId(postId).Click();
            }
            return _commentUnderPostById(creatorPostId, postId, creatorCommentId, commentId).State.WaitForExist();
        }

        public bool IsPostByTextAndUserIdHere(string text, string id)
        {
            return _userPostByUserIdAndText(text, id).State.WaitForExist();
        }

        public bool IsPostByTextUserIdAndContentIdHere(string text, string userId, string contentId)
        {
            return _userPostByUserIdTextAndContenId(text, userId, contentId).State.WaitForExist();
        }
    }
}
