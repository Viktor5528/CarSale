using AutoMapper;
using Car.Entity;
using DataLayer.Entity.EntityViewModel;

namespace Car.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentViewModel, Comment>();
        }
    }
}
