namespace SuggestionSystem.Services.Data.Contracts
{
    using SuggestionSystem.Data.Models;
    using System.Linq;
    using Web.DataTransferModels.Comment;
    using Web.DataTransferModels.Vote;

    public interface ISuggestionsService
    {
        IQueryable<Suggestion> GetAllSuggestions();

        IQueryable<Suggestion> GetSuggestionById(int id);

        Suggestion AddSuggestion(string userId, Suggestion suggestion);

        Suggestion UpdateSuggestionCommentsCount(Suggestion suggestionToUpdate, int newCommentsCount);

        Suggestion UpdateSuggestionsVotesCount(Suggestion suggestionToUpdate, int newUpVotesCount, int newDownVotesCount);
    }
}
