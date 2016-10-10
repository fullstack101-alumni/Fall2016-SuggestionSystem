namespace SuggestionSystem.Web.DataTransferModels.Comment
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class CommentResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentResponseModel>()
                .ForMember(c => c.Author, opts => opts.MapFrom(c => c.User.UserName));
        }
    }
}
