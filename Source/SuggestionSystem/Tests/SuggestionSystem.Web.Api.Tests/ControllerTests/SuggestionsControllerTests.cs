namespace SuggestionSystem.Web.Api.Tests.ControllerTests
{
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Setups;

    [TestClass]
    public class SuggestionsControllerTests
    {
        private IControllerBuilder<SuggestionsController> controller;

        [TestInitialize]
        public void Init()
        {
            this.controller = MyWebApi
                .Controller<SuggestionsController>()
                .WithResolvedDependencies(Services.GetSuggestionsService(), Services.GetCommentsService(), Services.GetVotesService());
        }

        [TestMethod]
        public void UserGetSuggestionsShouldNotReturnWaitingForApproveAndNotApprovedSuggestions()
        {
            controller
                .Calling(c => c.Get(1, 20, "DateCreated", null, null, false, false))
                .ShouldReturn()
                .Ok();
        }
    }
}