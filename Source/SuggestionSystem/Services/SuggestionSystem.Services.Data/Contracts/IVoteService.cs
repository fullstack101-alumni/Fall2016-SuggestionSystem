namespace SuggestionSystem.Services.Data.Contracts
{
    using SuggestionSystem.Data.Models;
    using System.Linq;
    using Web.DataTransferModels.Vote;

    public interface IVoteService
    {
        IQueryable<Vote> GetVote(int suggestionId, string userId);

        Vote AddVote(int suggestionId, string userId, Vote vote);

        Vote ModifyVote(Vote voteToModify, VoteRequestModel model);

        void Delete(Vote voteToDelete);
    }
}
