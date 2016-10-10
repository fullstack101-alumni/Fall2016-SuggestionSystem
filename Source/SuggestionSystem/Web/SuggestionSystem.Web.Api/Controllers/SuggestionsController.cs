namespace SuggestionSystem.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using DataTransferModels.Suggestion;
    using Services.Data.Contracts;
    using System.Web.Http;
    using System.Linq;

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
    }
}
