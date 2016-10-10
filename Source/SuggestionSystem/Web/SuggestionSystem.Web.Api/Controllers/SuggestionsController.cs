namespace SuggestionSystem.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using DataTransferModels.Suggestion;
    using Services.Data.Contracts;
    using System.Web.Http;
    using System.Linq;
    using Infrastructure.Validations;
    using Microsoft.AspNet.Identity;
    using Data.Models;
    using AutoMapper;

    public class SuggestionsController : ApiController
    {
        private readonly ISuggestionsService suggestions;

        public SuggestionsController(ISuggestionsService suggestions)
        {
            this.suggestions = suggestions;
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var result = this.suggestions
                .GetAllSuggestions()
                .ProjectTo<SuggestionResponseModel>()
                .ToList();
         
            return this.Ok(result);
        }

        [AllowAnonymous]
        [ValidateModel]
        public IHttpActionResult Post(SuggestionRequestModel model)
        {
            var userId = model.isAnonymous ? null : this.User.Identity.GetUserId();

            var newSuggestion = this.suggestions
                .AddSuggestion(userId, Mapper.Map<Suggestion>(model));

            return this.Created(
                string.Format("/api/suggestions/{0}", newSuggestion.Id),
                Mapper.Map<SuggestionResponseModel>(newSuggestion));
        }
    }
}
