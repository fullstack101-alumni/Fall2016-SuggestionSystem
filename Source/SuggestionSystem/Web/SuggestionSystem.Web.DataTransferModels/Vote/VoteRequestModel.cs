namespace SuggestionSystem.Web.DataTransferModels.Vote
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class VoteRequestModel
    {
        [Required]
        public VoteType Type { get; set; }
    }
}
