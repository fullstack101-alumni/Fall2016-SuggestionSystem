namespace SuggestionSystem.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using DataTransferModels.Suggestion;
    using Services.Data.Contracts;
    using System.Web.Http;
    using System.Linq;
    using Infrastructure.Validations;
    using Microsoft.AspNet.Identity;
    using Data.Models;
    using AutoMapper;
    using DataTransferModels.Comment;

    public class SuggestionsController : ApiController
    {
        private readonly ISuggestionsService suggestions;
        private readonly ICommentService comments;

        public SuggestionsController(ISuggestionsService suggestions, ICommentService comments)
        {
            this.suggestions = suggestions;
            this.comments = comments;
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var result = this.suggestions
                .GetAllSuggestions()
                .ProjectTo<SuggestionResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [AllowAnonymous]
        [ValidateModel]
        public IHttpActionResult Post(SuggestionRequestModel model)
        {
            var userId = model.isAnonymous ? null : this.User.Identity.GetUserId();

            var newSuggestion = this.suggestions
                .AddSuggestion(userId, Mapper.Map<Suggestion>(model));

            return this.Created(
                string.Format("/api/suggestions/{0}", newSuggestion.Id),
                Mapper.Map<SuggestionResponseModel>(newSuggestion));
        }

        [Authorize]
        [ValidateModel]
        [Route("api/suggestions/{id}/comment")]
        [HttpPost]
        public IHttpActionResult Comment(int id, CommentRequestModel model)
        {
            var newComment = this.comments
                .AddComment(id, this.User.Identity.GetUserId(), Mapper.Map<Comment>(model));

            return this.Created(
                string.Format("api/comments/{0}", newComment.Id),
                Mapper.Map<CommentResponseModel>(newComment));
        }
    }
}
