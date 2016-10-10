namespace SuggestionSystem.Web.DataTransferModels.Suggestion
{
    using AutoMapper;
    using Infrastructure.Mappings;
    using Data.Models;
    using System.Linq;

    public class SuggestionResponseModel : IMapFrom<Suggestion>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public string Author { get; set; }

        public SuggestionStatus Status { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Suggestion, SuggestionResponseModel>()
                .ForMember(s => s.UpVotes, opts => opts.MapFrom(s => s.Votes.Where(v => v.Type == VoteType.Up).Count()))
                .ForMember(s => s.DownVotes, opts => opts.MapFrom(s => s.Votes.Where(v => v.Type == VoteType.Down).Count()))
                .ForMember(s => s.Author, opts => opts.MapFrom(s => s.UserId != null ? s.User.UserName : "Anonymous"))
                .ForMember(s => s.CommentsCount, opts => opts.MapFrom(s => s.Comments.Count()));
        }
    }
}
