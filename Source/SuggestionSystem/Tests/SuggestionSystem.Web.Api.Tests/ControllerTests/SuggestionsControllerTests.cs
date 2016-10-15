namespace SuggestionSystem.Web.Api.Tests.ControllerTests
{
    using Controllers;
    using DataTransferModels.Comment;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Setups;
    using System.Linq;
    using System.Net;

    [TestClass]
    public class SuggestionsControllerTests
    {
        private IControllerBuilder<SuggestionsController> controller;

        [TestInitialize]
        public void Init()
        {
            this.controller = MyWebApi
                .Controller<SuggestionsController>()
                .WithResolvedDependencies(Services.GetSuggestionsService())
                .WithResolvedDependencies(Services.GetCommentsService())
                .WithResolvedDependencies(Services.GetVotesService());
        }

        [TestMethod]
        public void UserGetSuggestionsShouldNotReturnWaitingForApproveAndNotApprovedSuggestions()
        {
            var commentHttpResult = controller
                .Calling(c => c.Get(1, 20, "DateCreated", null, null, false, false))
                .ShouldReturn()
                .Ok();
        }
    }
}
