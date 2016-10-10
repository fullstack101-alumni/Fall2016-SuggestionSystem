namespace SuggestionSystem.Web.DataTransferModels.Comment
{
    using Infrastructure.Mappings;
    using SuggestionSystem.Common.Constants;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class CommentRequestModel : IMapFrom<Comment>
    {
        [Required]
        [MinLength(CommentsConstants.ContentMinLength)]
        [MaxLength(CommentsConstants.ContentMaxLength)]
        public string Content { get; set; }
    }
}
