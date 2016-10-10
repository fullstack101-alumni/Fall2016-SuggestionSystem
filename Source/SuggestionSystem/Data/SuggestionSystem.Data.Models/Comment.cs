namespace SuggestionSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int SuggestionId { get; set; }

        public virtual Suggestion Suggestion { get; set; }

        [Required]
        [MinLength(CommentsConstants.ContentMinLength)]
        [MaxLength(CommentsConstants.ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
