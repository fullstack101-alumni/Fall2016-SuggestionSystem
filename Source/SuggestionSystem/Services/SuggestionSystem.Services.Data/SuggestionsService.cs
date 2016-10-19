namespace SuggestionSystem.Services.Data
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using Contracts;
    using SuggestionSystem.Data.Models;
    using SuggestionSystem.Data.Repositories;
    using Web.DataTransferModels.Suggestion;
    using Common.Constants;

    public class SuggestionsService : ISuggestionsService
    {
        private readonly IRepository<Suggestion> suggestions;

        public SuggestionsService(IRepository<Suggestion> suggestions)
        {
            this.suggestions = suggestions;
        }

        public Suggestion AddSuggestion(string userId, Suggestion suggestion)
        {
            suggestion.DateCreated = DateTime.UtcNow;
            suggestion.UserId = userId;
            suggestion.Status = SuggestionStatus.WaitingForApproval;
            suggestion.UpVotesCount = 0;
            suggestion.DownVotesCount = 0;
            suggestion.CommentsCount = 0;

            this.suggestions.Add(suggestion);
            this.suggestions.SaveChanges();
            var count = this.suggestions.All().Count();
            return suggestion;
        }

        public Suggestion ChangeSuggestionStatus(Suggestion suggestionStatusToChange, SuggestionStatusRequestModel model)
        {
            suggestionStatusToChange.Status = model.Status;

            this.suggestions.SaveChanges();
            return suggestionStatusToChange;
        }

        public void Delete(Suggestion suggestion)
        {
            this.suggestions.Delete(suggestion);
            this.suggestions.SaveChanges();
        }

        public Suggestion UpdateSuggestion(Suggestion suggestionToUpdate, SuggestionRequestModel model)
        {
            suggestionToUpdate.Title = model.Title;
            suggestionToUpdate.Content = model.Content;
            suggestionToUpdate.isPrivate = model.isPrivate;

            this.suggestions.SaveChanges();
            return suggestionToUpdate;
        }
        /// <summary>
        /// Extraction method for suggestions
        /// </summary>
        /// <param name="page">Pagination parameter. Counting starts from 1. 
        /// This parameter has a wide contract i.e. one can pass negative values and they are handles gracefully.</param>
        /// <param name="itemsPerPage">Controls how many suggestions are returned. 
        /// The parameter is clammed by the global min and max items per page</param>
        /// <param name="orderBy">Orders suggestion by the provided member.</param>
        /// <param name="search">Search for a specific suggestion.</param>
        /// <param name="status">Returns suggestions with the specified status.
        /// Otherwise, returns all suggestions</param>
        /// <param name="onlyMine">Suggestion only of the current user</param>
        /// <param name="onlyUpVoted">Filter based on up-votes.</param>
        /// <param name="userId">Suggestions for a specific user id.</param>
        /// <param name="isAdmin">Flag whether the call is made by an admin.</param>
        /// <returns> A tuple of a sequence of suggestions and the count of all the suggestions that could be 
        /// returned by this query.</returns>
        public Tuple<IQueryable<Suggestion>, int> GetSuggestions(int page, int itemsPerPage, string orderBy, string search, string status, bool onlyMine, bool onlyUpVoted, string userId, bool isAdmin)
        {
            var suggestionsToReturn = this.suggestions.All();

            if (!isAdmin)
            {
                suggestionsToReturn = suggestionsToReturn
                    .Where(s => s.isPrivate == false && s.Status != SuggestionStatus.WaitingForApproval && s.Status != SuggestionStatus.NotApproved);
            }

            if (status != null)
            {
                suggestionsToReturn = suggestionsToReturn
                    .Where(s => s.Status == (SuggestionStatus)Enum.Parse(typeof(SuggestionStatus), status));
            }

            if (search != null)
            {
                suggestionsToReturn = suggestionsToReturn
                    .Where(s => s.Title.Contains(search) || s.Content.Contains(search));
            }

            if (onlyMine)
            {
                suggestionsToReturn = suggestionsToReturn
                    .Where(s => s.UserId == userId);
            }

            if (onlyUpVoted)
            {
                suggestionsToReturn = suggestionsToReturn
                    .Where(s => s.Votes.Where(v => v.Type == VoteType.Up).Select(v => v.UserId).Equals(userId));
            }

            if (orderBy != null)
            {
                suggestionsToReturn = suggestionsToReturn.OrderByDescending(s => orderBy);
            }

            var suggestionsCount = suggestionsToReturn.Count();

            page = page >= 0 ? page : SuggestionsConstants.DefaultPage;
            itemsPerPage = itemsPerPage >= SuggestionsConstants.MinimalSuggestionsPerPage ? itemsPerPage : SuggestionsConstants.MinimalSuggestionsPerPage;
            itemsPerPage = itemsPerPage <= SuggestionsConstants.MaximalSuggestionsPerPage ? itemsPerPage : SuggestionsConstants.MaximalSuggestionsPerPage;

            suggestionsToReturn = suggestionsToReturn
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage);

            return new Tuple<IQueryable<Suggestion>, int>(suggestionsToReturn, suggestionsCount);
        }

        public IQueryable<Suggestion> GetSuggestionById(int id)
        {
            return this.suggestions
                .All()
                .Where(s => s.Id == id);
        }

        public Suggestion UpdateSuggestionCommentsCount(Suggestion suggestionToUpdate, int newCommentsCount)
        {
            suggestionToUpdate.CommentsCount = newCommentsCount;

            this.suggestions.SaveChanges();
            return suggestionToUpdate;
        }

        public Suggestion UpdateSuggestionsVotesCount(Suggestion suggestionToUpdate, int newUpVotesCount, int newDownVotesCount)
        {
            suggestionToUpdate.UpVotesCount = newUpVotesCount;
            suggestionToUpdate.DownVotesCount = newDownVotesCount;

            this.suggestions.SaveChanges();
            return suggestionToUpdate;
        }

        public bool UserIsEligibleToGetSuggestion(Suggestion suggestion, bool isAdmin)
        {
            return (isAdmin) ||
                !(suggestion.isPrivate ||
                suggestion.Status == SuggestionStatus.WaitingForApproval ||
                suggestion.Status == SuggestionStatus.NotApproved);
        }

        public bool UserIsEligibleToModifySuggestion(Suggestion suggestion, string userId, bool isAdmin)
        {
            return (isAdmin) ||
                !(suggestion.UserId == null ||
                suggestion.UserId != userId ||
                suggestion.Status != SuggestionStatus.WaitingForApproval);
        }
    }
}
