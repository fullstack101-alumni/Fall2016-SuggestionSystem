namespace SuggestionSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int SuggestionId { get; set; }

        public virtual Suggestion Suggestion { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
