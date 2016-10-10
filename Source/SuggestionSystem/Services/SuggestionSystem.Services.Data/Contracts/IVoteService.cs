namespace SuggestionSystem.Services.Data.Contracts
{
    using SuggestionSystem.Data.Models;
    using Web.DataTransferModels.Vote;

    public interface IVoteService
    {
        Vote GetVote(int suggestionId, string userId);

        Vote AddVote(int suggestionId, string userId, Vote vote);

        Vote ModifyVote(Vote voteToModify, VoteRequestModel model);
    }
}
