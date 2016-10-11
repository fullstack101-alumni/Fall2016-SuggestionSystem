namespace SuggestionSystem.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using SuggestionSystem.Data.Models;
    using Web.DataTransferModels.Suggestion;

    public interface ISuggestionsService
    {
        Tuple<IQueryable<Suggestion>, int> GetSuggestions(int page, int itemsPerPage, string orderBy, string search, string status, bool onlyMine, bool onlyUpVoted, string userId, bool isAdmin);

        IQueryable<Suggestion> GetSuggestionById(int id);

        Suggestion AddSuggestion(string userId, Suggestion suggestion);

        Suggestion UpdateSuggestionCommentsCount(Suggestion suggestionToUpdate, int newCommentsCount);

        Suggestion UpdateSuggestionsVotesCount(Suggestion suggestionToUpdate, int newUpVotesCount, int newDownVotesCount);

        void Delete(Suggestion suggestion);

        Suggestion UpdateSuggestion(Suggestion suggestionToUpdate, SuggestionRequestModel model);

        Suggestion ChangeSuggestionStatus(Suggestion suggestionStatusToChange, SuggestionStatusRequestModel model);

        bool UserIsEligibleToGetSuggestion(Suggestion suggestion, bool isAdmin);

        bool UserIsEligibleToModifySuggestion(Suggestion suggestion, string userId, bool isAdmin);
    }
}
