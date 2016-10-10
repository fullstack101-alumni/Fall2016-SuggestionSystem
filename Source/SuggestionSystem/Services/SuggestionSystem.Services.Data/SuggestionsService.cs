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

        public IQueryable<Suggestion> GetAllSuggestions()
        {
            return this.suggestions.All();
        }
    }
}
