namespace SuggestionSystem.Services.Data
{
    using System;
    using SuggestionSystem.Data.Models;
    using SuggestionSystem.Services.Data.Contracts;
    using SuggestionSystem.Data.Repositories;
    
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
    }
}