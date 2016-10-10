namespace SuggestionSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using SuggestionSystem.Data.Models;
    using SuggestionSystem.Data.Repositories;

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

            this.suggestions.Add(suggestion);
            this.suggestions.SaveChanges();

            return suggestion;
        }

        public IQueryable<Suggestion> GetAllSuggestions()
        {
            return this.suggestions.All();
        }
    }
}
