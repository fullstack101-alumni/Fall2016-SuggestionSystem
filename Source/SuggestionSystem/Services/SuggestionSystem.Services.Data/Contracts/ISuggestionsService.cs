namespace SuggestionSystem.Services.Data.Contracts
{
    using SuggestionSystem.Data.Models;
    using System.Linq;

    public interface ISuggestionsService
    {
        IQueryable<Suggestion> GetAllSuggestions();

        Suggestion AddSuggestion(string userId, Suggestion suggestion);
    }
}
