namespace SuggestionSystem.Web.DataTransferModels.Suggestion
{
    using System;
    using AutoMapper;
    using Infrastructure.Mappings;
    using Data.Models;
    using System.Linq;

    public class SuggestionResponseModel : IMapFrom<Suggestion>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int UpVotesCount { get; set; }

        public int DownVotesCount { get; set; }

        public string Author { get; set; }

        public SuggestionStatus Status { get; set; }

        public int CommentsCount { get; set; }

        public DateTime DateCreated { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Suggestion, SuggestionResponseModel>()
                .ForMember(s => s.Author, opts => opts.MapFrom(s => s.UserId != null ? s.User.UserName : "Anonymous"));
        }
    }
}
