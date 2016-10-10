namespace SuggestionSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using SuggestionSystem.Data.Models;
    using SuggestionSystem.Data.Repositories;
    using Web.DataTransferModels.Comment;
    using Web.DataTransferModels.Vote;

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

            return suggestion;
        }

        public void Delete(Suggestion suggestion)
        {
            this.suggestions.Delete(suggestion);
            this.suggestions.SaveChanges();
        }

        public IQueryable<Suggestion> GetAllSuggestions()
        {
            return this.suggestions.All();
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
    }
}
