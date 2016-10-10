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

        [Authorize]
        public IHttpActionResult Delete(int id, string userId)
        {
            var suggestion = this.suggestions
                .GetSuggestionById(id)
                .SingleOrDefault();

            if(suggestions == null)
            {
                return this.BadRequest("Suggestion does not exist");
            }

            if (suggestion.UserId == null || suggestion.UserId != this.User.Identity.GetUserId())
            {
                return this.BadRequest("You are not permitted to modify suggestions that are not yours.");
            }

            this.suggestions.Delete(suggestion);

            return this.Ok("Suggestion deleted.");
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Put(int id, SuggestionRequestModel model)
        {
            var suggestion = this.suggestions
               .GetSuggestionById(id)
               .SingleOrDefault();

            if (suggestions == null)
            {
                return this.BadRequest("Suggestion does not exist");
            }

            if (suggestion.UserId == null || suggestion.UserId != this.User.Identity.GetUserId())
            {
                return this.BadRequest("You are not permitted to modify suggestions that are not yours.");
            }

            var newSuggestion = this.suggestions
                .UpdateSuggestion(suggestion, model);

            return this.Ok(Mapper.Map<SuggestionResponseModel>(newSuggestion));
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
            var suggestion = this.suggestions
                .GetSuggestionById(id)
                .SingleOrDefault();

            if (suggestion == null)
            {
                return this.BadRequest("Suggestion does not exist");
            }

            var newComment = this.comments
                .AddComment(id, this.User.Identity.GetUserId(), Mapper.Map<Comment>(model));

            var updatedSuggestion = this.suggestions
                .UpdateSuggestionCommentsCount(suggestion, suggestion.CommentsCount + 1);

            var result = Mapper.Map<CommentResponseModel>(newComment);
            result.CommentsCount = updatedSuggestion.CommentsCount;

            return this.Ok(result);
        }

        [Authorize]
        [ValidateModel]
        [Route("api/suggestions/{id}/vote")]
        [HttpPut]
        public IHttpActionResult Vote(int id, VoteRequestModel model)
        {
            var suggestion = this.suggestions
                .GetSuggestionById(id)
                .SingleOrDefault();

            if (suggestion == null)
            {
                return this.BadRequest("Suggestion does not exist");
            }

            var userId = this.User.Identity.GetUserId();

            var vote = this.votes
                .GetVote(id, userId)
                .SingleOrDefault();

            Vote newVote;
            Suggestion updatedSuggestion;
            if (vote == null)
            {
                newVote = this.votes
                    .AddVote(id, userId, Mapper.Map<Vote>(model));

                updatedSuggestion =
                    model.Type == VoteType.Up ?
                    this.suggestions.UpdateSuggestionsVotesCount(suggestion, suggestion.UpVotesCount + 1, suggestion.DownVotesCount) :
                    this.suggestions.UpdateSuggestionsVotesCount(suggestion, suggestion.UpVotesCount, suggestion.DownVotesCount + 1);
            }
            else
            {
                if (model.Type == vote.Type)
                {
                    this.votes.Delete(vote);

                    updatedSuggestion =
                        model.Type == VoteType.Up ?
                        this.suggestions.UpdateSuggestionsVotesCount(suggestion, suggestion.UpVotesCount - 1, suggestion.DownVotesCount) :
                        this.suggestions.UpdateSuggestionsVotesCount(suggestion, suggestion.UpVotesCount, suggestion.DownVotesCount - 1);
                }
                else
                {
                    newVote = this.votes
                        .ModifyVote(vote, model);

                    updatedSuggestion =
                        model.Type == VoteType.Up ?
                        this.suggestions.UpdateSuggestionsVotesCount(suggestion, suggestion.UpVotesCount + 1, suggestion.DownVotesCount - 1) :
                        this.suggestions.UpdateSuggestionsVotesCount(suggestion, suggestion.UpVotesCount - 1, suggestion.DownVotesCount + 1);
                }
            }

            return this.Ok(Mapper.Map<SuggestionVoteResponseModel>(updatedSuggestion));
        }
    }
}
