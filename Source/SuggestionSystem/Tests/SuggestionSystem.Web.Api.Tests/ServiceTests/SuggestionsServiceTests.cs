namespace SuggestionSystem.Web.Api.Tests.ServiceTests
{
    using Common.Constants;
    using Data.Models;
    using Data.Repositories;
    using DataTransferModels.Suggestion;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Services.Data;
    using Setups;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class SuggestionsServiceTests
    {

        private SuggestionsService suggestions;

        [TestInitialize]
        public void Init()
        {
            var suggestionsRepository = Repositories.GetSuggestionsRepository();
            this.suggestions = new SuggestionsService(suggestionsRepository);
        }

        [TestMethod]
        public void GetSuggestionsCountWhenAdminIsFalse()
        {
            var result = this.suggestions.GetSuggestions(1, 10, null, null, null, false, false, "User1", false);
            Assert.AreEqual(1, result.Item1.Count());
        }

        [TestMethod]
        public void GetSuggestionsCountWhenAdminIsTrue()
        {
            var result = this.suggestions.GetSuggestions(1, 10, null, null, null, false, false, "User1", true);
            Assert.AreEqual(2, result.Item1.Count());
        }

        [TestMethod]
        public void GetSuggestionsCountWhenAdminIsTrueAndUserIs2()
        {
            var result = this.suggestions.GetSuggestions(1, 10, null, null, null, false, false, "User2", true);
            Assert.AreEqual(2, result.Item1.Count());
        }

        [TestMethod]
        public void GetSuggestionsCountWhenAdminIsFalseAndSkip1Page()
        {
            var result = this.suggestions.GetSuggestions(2, 10, null, null, null, false, false, "User1", false);
            Assert.AreEqual(0, result.Item1.Count());
        }

        [TestMethod]
        public void GetSuggestionsCount()
        {
            var result = this.suggestions.GetSuggestions(0, 100, null, null, null, false, false, "User1", false);
            Assert.AreEqual(1, result.Item1.Count());
        }

        [TestMethod]
        public void GetSuggestionsId()
        {
            var result = this.suggestions.GetSuggestionById(1);
            Assert.AreEqual("Suggestion 1", result.ElementAt(0).Title);
        }

        [TestMethod]
        public void ChangeSuggestionStatus()
        {
            var suggestion = this.suggestions.GetSuggestionById(1).ElementAt(0);
            var oldStatus = suggestion.Status;
            var suggestionStatusRequest = new SuggestionStatusRequestModel { Status = SuggestionStatus.Rejected };
            suggestion = this.suggestions.ChangeSuggestionStatus(suggestion, suggestionStatusRequest);
            Assert.AreNotEqual(oldStatus, suggestion.Status);
        }

        [TestMethod]
        public void UpdateSuggestion()
        {
            var suggestion = this.suggestions.GetSuggestionById(1).ElementAt(0);
            var newTitle = "New title for the suggestion";
            var newContent = "New content for the suggestion";
            var suggestionRequest = new SuggestionRequestModel {
                Title = newTitle,
                Content = newContent,
                isAnonymous = false,
                isPrivate = true
            };
            suggestion = this.suggestions.UpdateSuggestion(suggestion, suggestionRequest);
            Assert.AreEqual(newTitle, suggestion.Title);
            Assert.AreEqual(newContent, suggestion.Content);
        }

        [TestMethod]
        public void UpdateSuggestionCommentsCount()
        {
            var suggestion = this.suggestions.GetSuggestionById(1).ElementAt(0);
            var newCommentsCount = 13;
            suggestion = this.suggestions.UpdateSuggestionCommentsCount(suggestion, newCommentsCount);
            Assert.AreEqual(newCommentsCount, suggestion.CommentsCount);
        }

        [TestMethod]
        public void UpdateSuggestionVotesCount()
        {
            var suggestion = this.suggestions.GetSuggestionById(1).ElementAt(0);
            var newVotesUpCount = 5;
            var newVotesDownCount = 10;
            suggestion = this.suggestions.UpdateSuggestionsVotesCount(suggestion, newVotesUpCount, newVotesDownCount);
            Assert.AreEqual(newVotesUpCount, suggestion.UpVotesCount);
            Assert.AreEqual(newVotesDownCount, suggestion.DownVotesCount);
        }

        [TestMethod]
        public void UserIsEligibleToGetSuggestionWhenUserIsAdmin()
        {
            var suggestion = this.suggestions.GetSuggestionById(1).ElementAt(0);
            var isEligible = this.suggestions.UserIsEligibleToGetSuggestion(suggestion, true);
            Assert.AreEqual(true, isEligible);
        }

        [TestMethod]
        public void UserIsEligibleToGetSuggestionWhenUserIsNotAdminAndSuggestionIsPrivate()
        {
            var suggestion = this.suggestions.GetSuggestionById(2).ElementAt(0);
            var isEligible = this.suggestions.UserIsEligibleToGetSuggestion(suggestion, false);
            Assert.AreEqual(false, isEligible);
        }

        [TestMethod]
        public void UserIsEligibleToGetSuggestionWhenUserIsNotAdminAndSuggestionIsPublic()
        {
            var suggestion = this.suggestions.GetSuggestionById(1).ElementAt(0);
            var isEligible = this.suggestions.UserIsEligibleToGetSuggestion(suggestion, false);
            Assert.AreEqual(true, isEligible);
        }

        [TestMethod]
        public void UserIsEligibleToModifySuggestionWhenUserIsAdmin()
        {
            var suggestion = this.suggestions.GetSuggestionById(1).ElementAt(0);
            var isEligible = this.suggestions.UserIsEligibleToModifySuggestion(suggestion, "User1", true);
            Assert.AreEqual(true, isEligible);
        }

        [TestMethod]
        public void UserIsEligibleToModifySuggestionWhenUserIsNotAdminAndSuggestionIsPrivateAndItIsTheirSuggestionsAndStatusIsWaitingForApproval()
        {
            var suggestion = this.suggestions.GetSuggestionById(2).ElementAt(0);
            suggestion.Status = SuggestionStatus.WaitingForApproval;
            var isEligible = this.suggestions.UserIsEligibleToModifySuggestion(suggestion, "User1", false);
            Assert.AreEqual(true, isEligible);
        }

        [TestMethod]
        public void UserIsEligibleToModifySuggestionWhenUserIsNotAdminAndSuggestionIsPrivateAndItIsNotTheirSuggestionsAndStatusIsWaitingForApproval()
        {
            var suggestion = this.suggestions.GetSuggestionById(2).ElementAt(0);
            suggestion.Status = SuggestionStatus.WaitingForApproval;
            var isEligible = this.suggestions.UserIsEligibleToModifySuggestion(suggestion, "User2", false);
            Assert.AreEqual(false, isEligible);
        }

    }
}
