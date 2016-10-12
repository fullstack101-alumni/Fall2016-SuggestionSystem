namespace SuggestionSystem.Web.Api.Tests.Setups
{
    using Data.Models;
    using Data.Repositories;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;

    public class Repositories
    {
        public static IRepository<Suggestion> GetSuggestionsRepository()
        {
            var repository = new Mock<IRepository<Suggestion>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Suggestion>
                {
                    new Suggestion {  }
                }.AsQueryable();
            });

            return repository.Object;
        }

        public static IRepository<Comment> GetCommentsRepository()
        {
            var repository = new Mock<IRepository<Comment>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Comment>
                {
                    new Comment {  }
                }.AsQueryable();
            });

            return repository.Object;
        }

        public static IRepository<Vote> GetVotesRepository()
        {
            var repository = new Mock<IRepository<Vote>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Vote>
                {
                    new Vote {  }
                }.AsQueryable();
            });

            return repository.Object;
        }
    }
}
