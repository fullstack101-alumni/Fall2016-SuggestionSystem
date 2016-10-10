namespace SuggestionSystem.Services.Data.Contracts
{
    using SuggestionSystem.Data.Models;

    public interface ICommentService
    {
        Comment AddComment(int suggestionId, string userId, Comment comment);
    }
}
