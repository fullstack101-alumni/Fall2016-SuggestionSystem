namespace SuggestionSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Suggestion
    {
        private ICollection<Vote> votes;
        private ICollection<Comment> comments;

        public Suggestion()
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MinLength(SuggestionsConstants.TitleMinLength)]
        [MaxLength(SuggestionsConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(SuggestionsConstants.ContentMinLength)]
        [MaxLength(SuggestionsConstants.ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public SuggestionStatus Status { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool isPrivate { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
