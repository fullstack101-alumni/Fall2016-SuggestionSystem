namespace SuggestionSystem.Services.Data.Contracts
{
    using System.Linq;
    using SuggestionSystem.Data.Models;
    
    public interface ICommentService
    {
        Comment AddComment(int suggestionId, string userId, Comment comment);

        IQueryable<Comment> GetCommentsForSuggestion(int id, int from, int count);
    }
}
