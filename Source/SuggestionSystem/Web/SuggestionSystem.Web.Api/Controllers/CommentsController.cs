namespace SuggestionSystem.Web.Api.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Http;
    using System.Linq;
    using Infrastructure.Validations;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using DataTransferModels.Comment;
    using Common.Constants;
    public class CommentsController : ApiController
    {
        private readonly ICommentService comments;

        public CommentsController(ICommentService comments)
        {
            this.comments = comments;
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var comment = this.comments
                .GetCommentById(id)
                .SingleOrDefault();

            if (comment == null)
            {
                return this.NotFound();
            }

            if (!this.comments.UserIsEligibleToModifyComment(comment, this.User.Identity.GetUserId(), this.User.IsInRole(UserConstants.AdminRole)))
            {
                return this.BadRequest("You are not allowed to modify this comment!");
            }

            this.comments.Delete(comment);

            return this.Ok("Comment deleted.");
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Put(int id, CommentRequestModel model)
        {
            var comment = this.comments
               .GetCommentById(id)
               .SingleOrDefault();

            if (comment == null)
            {
                return this.NotFound();
            }

            if (!this.comments.UserIsEligibleToModifyComment(comment, this.User.Identity.GetUserId(), this.User.IsInRole(UserConstants.AdminRole)))
            {
                return this.BadRequest("You are not allowed to modify this comment!");
            }

            var updatedComment = this.comments
                .UpdateComment(comment, model);

            return this.Ok(Mapper.Map<CommentResponseModel>(updatedComment));
        }

    }
}