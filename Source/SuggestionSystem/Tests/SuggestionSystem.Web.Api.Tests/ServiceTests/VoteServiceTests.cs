namespace SuggestionSystem.Web.Api.Tests.ServiceTests
{
    using DataTransferModels.Vote;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SuggestionSystem.Data.Models;
    using SuggestionSystem.Services.Data;
    using SuggestionSystem.Web.Api.Tests.Setups;
    using System.Linq;

    [TestClass]
    public class VoteServiceTests
    {
        private VoteService votes;

        [TestInitialize]
        public void Init()
        {
            this.votes = new VoteService(Repositories.GetVotesRepository());
        }

        [TestMethod]
        public void GetVoteForIDAndUser()
        {
            var vote = this.votes.GetVote(1, "User3").SingleOrDefault();
            
            Assert.AreEqual(VoteType.Down, vote.Type);
        }

        [TestMethod]
        public void ModifyVoteContent()
        {
            var vote = this.votes.GetVote(1, "User3").SingleOrDefault();
            Assert.AreEqual(VoteType.Down, vote.Type);

            VoteRequestModel model = new VoteRequestModel();
            model.Type = VoteType.Up;
            this.votes.ModifyVote(vote, model);

            Assert.AreEqual(VoteType.Up, vote.Type);
        }
    }
}
