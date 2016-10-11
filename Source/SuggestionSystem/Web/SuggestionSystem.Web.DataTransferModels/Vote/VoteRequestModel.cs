namespace SuggestionSystem.Web.DataTransferModels.Vote
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mappings;
    
    public class VoteRequestModel : IMapFrom<Vote>
    {
        [Required]
        public VoteType Type { get; set; }
    }
}
