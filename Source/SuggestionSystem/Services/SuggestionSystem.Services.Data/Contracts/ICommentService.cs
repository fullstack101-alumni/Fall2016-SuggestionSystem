namespace SuggestionSystem.Services.Data.Contracts
{
    using System.Linq;
    using SuggestionSystem.Data.Models;
    using Web.DataTransferModels.Comment;

    public interface ICommentService
    {
        Comment AddComment(int suggestionId, string userId, Comment comment);

        void Delete(Comment suggestion);

        Comment UpdateComment(Comment commentToUpdate, CommentRequestModel model);

        IQueryable<Comment> GetCommentsForSuggestion(int id, int from, int count);

        IQueryable<Comment> GetCommentById(int id);

        bool UserIsEligibleToModifyComment(Comment comment, string userId, bool isAdmin);
    }
}
