namespace SuggestionSystem.Services.Data.Contracts
{
    using SuggestionSystem.Data.Models;
    using System.Linq;
    using Web.DataTransferModels.Suggestion;

    public interface ISuggestionsService
    {
        IQueryable<Suggestion> GetAllSuggestions();

        IQueryable<Suggestion> GetSuggestionById(int id);

        Suggestion AddSuggestion(string userId, Suggestion suggestion);

        Suggestion UpdateSuggestionCommentsCount(Suggestion suggestionToUpdate, int newCommentsCount);

        Suggestion UpdateSuggestionsVotesCount(Suggestion suggestionToUpdate, int newUpVotesCount, int newDownVotesCount);

        void Delete(Suggestion suggestion);

        Suggestion UpdateSuggestion(Suggestion suggestionToUpdate, SuggestionRequestModel model);

        Suggestion ChangeSuggestionStatus(Suggestion suggestionStatusToChange, SuggestionStatusRequestModel model);
    }
}
