namespace SuggestionSystem.Web.DataTransferModels.Suggestion
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mappings;

    public class SuggestionRequestModel : IMapFrom<Suggestion>
    {

        [Required]
        [MinLength(SuggestionsConstants.TitleMinLength)]
        [MaxLength(SuggestionsConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(SuggestionsConstants.ContentMinLength)]
        [MaxLength(SuggestionsConstants.ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public bool isPrivate { get; set; }

        [Required]
        public bool isAnonymous { get; set; }
    }
}
