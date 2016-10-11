namespace SuggestionSystem.Web.DataTransferModels.Suggestion
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mappings;

    public class SuggestionStatusRequestModel : IMapFrom<Suggestion>
    {
        [Required]
        public SuggestionStatus Status { get; set; }
    }
}
