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
    using DataTransferModels.Vote;

    public class SuggestionsController : ApiController
    {
        private readonly ISuggestionsService suggestions;
        private readonly ICommentService comments;
        private readonly IVoteService votes;

        public SuggestionsController(ISuggestionsService suggestions, ICommentService comments, IVoteService votes)
        {
            this.suggestions = suggestions;
            this.comments = comments;
            this.votes = votes;
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

        [Authorize]
        [ValidateModel]
        [Route("api/suggestions/{id}/vote")]
        [HttpPut]
        public IHttpActionResult Vote(int id, VoteRequestModel model)
        {
            var userId = this.User.Identity.GetUserId();

            var vote = this.votes
                .GetVote(id, userId);

            Vote newVote;
            if (vote == null)
            {
                newVote = this.votes
                    .AddVote(id, userId, Mapper.Map<Vote>(model));
            }
            else
            {
                newVote = this.votes
                    .ModifyVote(vote, model);
            }

            return this.Ok(newVote);
        }
    }
}
