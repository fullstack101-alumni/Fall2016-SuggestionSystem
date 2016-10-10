namespace SuggestionSystem.Web.DataTransferModels.Suggestion
{
    using SuggestionSystem.Web.Infrastructure.Mappings;
    using Data.Models;

    public class SuggestionVoteResponseModel : IMapFrom<Suggestion>
    {
        public int UpVotesCount { get; set; }

        public int DownVotesCount { get; set; }
    }
}
