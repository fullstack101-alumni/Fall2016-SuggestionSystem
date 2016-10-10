namespace SuggestionSystem.Services.Data
{
    using System;
    using System.Linq;
    using SuggestionSystem.Data.Models;
    using SuggestionSystem.Data.Repositories;
    using SuggestionSystem.Services.Data.Contracts;
    using Web.DataTransferModels.Vote;

    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> votes;

        public VoteService(IRepository<Vote> votes)
        {
            this.votes = votes;
        }

        public IQueryable<Vote> GetVote(int suggestionId, string userId)
        {
            return this.votes
                .All()
                .Where(v => v.SuggestionId == suggestionId && v.UserId == userId);
        }

        public Vote AddVote(int suggestionId, string userId, Vote vote)
        {
            vote.SuggestionId = suggestionId;
            vote.UserId = userId;

            this.votes.Add(vote);
            this.votes.SaveChanges();

            return vote;
        }

        public Vote ModifyVote(Vote voteToModify, VoteRequestModel model)
        {
            voteToModify.Type = model.Type;

            this.votes.SaveChanges();
            return voteToModify;
        }

        public void Delete(Vote voteToDelete)
        {
            this.votes.Delete(voteToDelete);
            this.votes.SaveChanges();
        }
    }
}
