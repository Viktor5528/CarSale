using AutoMapper;
using Car.Entity;
using DataLayer.Entity.EntityViewModel;

namespace Car.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandViewModel, Brand>()
                .ForMember(cbm => cbm.Name, x => x.MapFrom(br => br.Brand));
        }
    }
}
