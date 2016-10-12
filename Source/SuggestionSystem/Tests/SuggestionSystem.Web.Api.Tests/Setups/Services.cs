namespace SuggestionSystem.Web.Api.Tests.Setups
{
    using SuggestionSystem.Services.Data.Contracts;
    using SuggestionSystem.Services.Data;

    public class Services
    {
        public static ISuggestionsService GetSuggestionsService()
        {
            return new SuggestionsService(Repositories.GetSuggestionsRepository());
        }

        public static ICommentService GetCommentsService()
        {
            return new CommentService(Repositories.GetCommentsRepository());
        }

        public static IVoteService GetVotesService()
        {
            return new VoteService(Repositories.GetVotesRepository());
        }
    }
}
