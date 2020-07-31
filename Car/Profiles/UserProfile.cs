using AutoMapper;
using Car.Controllers;
using Car.Entity;
using DataLayer.Entity.EntityViewModel;

namespace Car.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserViewModel, User>()
                .ForMember(p => p.Password, x => x.MapFrom(o => HashHelper.GetMd5(o.Password)));
        }
    }
}
