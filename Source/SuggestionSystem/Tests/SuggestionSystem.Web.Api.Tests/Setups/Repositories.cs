namespace SuggestionSystem.Web.Api.Tests.Setups
{
    using Data.Models;
    using Data.Repositories;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Repositories
    {
        public static IRepository<User> GetAccountsRepository()
        {
            var repository = new Mock<IRepository<User>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<User>
                {
                    new User {
                        Id = "User1",
                        Email = "aaa100@aubg.edu",
                        EmailConfirmed = false,
                        UserName = "aaa100@aubg.edu"
                    },
                    new User {
                        Id = "User2",
                        Email = "bbb100@aubg.edu",
                        EmailConfirmed = false,
                        UserName = "aaa100@aubg.edu"
                    },
                    new User {
                        Id = "User3",
                        Email = "ccc100@aubg.edu",
                        EmailConfirmed = false,
                        UserName = "ccc100@aubg.edu"
                    }

                }.AsQueryable();
            });

            repository.Setup(r => r.SaveChanges()).Verifiable();

            return repository.Object;
        }

        public static IRepository<Suggestion> GetSuggestionsRepository()
        {
            var repository = new Mock<IRepository<Suggestion>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Suggestion>
                {
                    new Suggestion {
                        Id = 1,
                        UserId = "User1",
                        Title = "Suggestion 1",
                        Content = "Some Suggestion",
                        Status = SuggestionStatus.Accepted,
                        DateCreated = new DateTime(1000),
                        isPrivate = false,
                        UpVotesCount = 2,
                        DownVotesCount = 1,
                        CommentsCount = 2
                    },
                    new Suggestion {
                        Id = 2,
                        UserId = "User1",
                        Title = "Suggestion 2",
                        Content = "Some Other Suggestion",
                        Status = SuggestionStatus.Rejected,
                        DateCreated = new DateTime(15000),
                        isPrivate = true,
                        UpVotesCount = 0,
                        DownVotesCount = 0,
                        CommentsCount = 0
                    }

                }.AsQueryable();
            });

            repository.Setup(r => r.SaveChanges()).Verifiable();

            return repository.Object;
        }

        public static IRepository<Comment> GetCommentsRepository()
        {
            var repository = new Mock<IRepository<Comment>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Comment>
                {
                    new Comment
                    {
                        Id = 1,
                        UserId = "User2",
                        SuggestionId = 1,
                        Content = "Some random comment about the suggestions.",
                        DateCreated = new DateTime(10000)
                    },
                    new Comment
                    {
                        Id = 2,
                        UserId = "User1",
                        SuggestionId = 1,
                        Content = "Some random other comment about the suggestions.",
                        DateCreated = new DateTime(13000)
                    }
                }.AsQueryable();
            });

            repository.Setup(r => r.SaveChanges()).Verifiable();

            return repository.Object;
        }

        public static IRepository<Vote> GetVotesRepository()
        {
            var repository = new Mock<IRepository<Vote>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Vote>
                {
                    new Vote
                    {
                        Id = 1,
                        UserId = "User1",
                        SuggestionId = 1,
                        Type = VoteType.Up
                    },
                    new Vote
                    {
                        Id = 2,
                        UserId = "User2",
                        SuggestionId = 1,
                        Type = VoteType.Up
                    },
                    new Vote
                    {
                        Id = 3,
                        UserId = "User3",
                        SuggestionId = 1,
                        Type = VoteType.Down
                    }
                }.AsQueryable();
            });

            repository.Setup(r => r.SaveChanges()).Verifiable();

            return repository.Object;
        }
    }
}
