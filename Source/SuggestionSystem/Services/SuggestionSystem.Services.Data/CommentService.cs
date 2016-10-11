namespace SuggestionSystem.Services.Data
{
    using System;
    using SuggestionSystem.Data.Models;
    using SuggestionSystem.Services.Data.Contracts;
    using SuggestionSystem.Data.Repositories;
    using System.Linq;

    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;

        public CommentService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment AddComment(int suggestionId, string userId, Comment comment)
        {
            comment.DateCreated = DateTime.UtcNow;
            comment.SuggestionId = suggestionId;
            comment.UserId = userId;

            this.comments.Add(comment);
            this.comments.SaveChanges();

            return comment;
        }

        public IQueryable<Comment> GetCommentsForSuggestion(int id, int from, int count)
        {
            return this.comments.All()
                .Where(c => c.SuggestionId == id)
                .OrderBy(c => c.DateCreated)
                .Skip(from)
                .Take(count);
        }
    }
}