namespace SuggestionSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Vote
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
        public VoteType Type { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
