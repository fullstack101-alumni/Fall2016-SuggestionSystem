namespace SuggestionSystem.Web.Api.Tests.ServiceTests
{
    using Data.Models;
    using DataTransferModels.Comment;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SuggestionSystem.Services.Data;
    using SuggestionSystem.Web.Api.Tests.Setups;
    using System;
    using System.Linq;

    [TestClass]
    public class CommentServiceTests
    {
        private CommentService comments;

        [TestInitialize]
        public void Init()
        {
            this.comments = new CommentService(Repositories.GetCommentsRepository());
        }

        [TestMethod]
        public void GetCommentsForSuggestion()
        {
            var subSetOfComments = this.comments.GetCommentsForSuggestion(1, 1, 10);
            var comments = this.comments.GetCommentsForSuggestion(1, 0, 10);

            Assert.AreEqual(1, subSetOfComments.Count());
            Assert.AreEqual(2, comments.Count());            
        }

        [TestMethod]
        public void GetCommentById()
        {
            var result = this.comments.GetCommentById(1);

            Assert.AreEqual("User2", result.SingleOrDefault().UserId);
            Assert.AreEqual(1, result.SingleOrDefault().SuggestionId);
        }

        [TestMethod]
        public void CheckPermissionsForCommentModificationAdmin()
        {
            var comment = this.comments.GetCommentById(1).SingleOrDefault();
            var result = this.comments.UserIsEligibleToModifyComment(comment, null, true);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckPermissionsForCommentModificationNoPermission()
        {
            var comment = this.comments.GetCommentById(1).SingleOrDefault();
            var resultAdmin = this.comments.UserIsEligibleToModifyComment(comment, null, false);
            var resultOtherUser = this.comments.UserIsEligibleToModifyComment(comment, "dsadadsa", false);

            Assert.IsFalse(resultAdmin);
            Assert.IsFalse(resultOtherUser);
        }

        [TestMethod]
        public void CheckPermissionsForCommentModificationUserPermission()
        {
            var comment = this.comments.GetCommentById(1).SingleOrDefault();
            var result = this.comments.UserIsEligibleToModifyComment(comment, "User2", false);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateComment_ModifyCommentContent()
        {
            var comment = this.comments.GetCommentById(1).SingleOrDefault();
            CommentRequestModel model = new CommentRequestModel();
            model.Content = "New Content";
            this.comments.UpdateComment(comment, model);
            var verifyStupidity = this.comments.GetCommentById(1).SingleOrDefault().Content;
            Assert.AreEqual("New Content", comment.Content);
        }
    }
}