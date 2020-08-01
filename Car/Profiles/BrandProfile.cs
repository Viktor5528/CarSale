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
                .ForMember(br => br.Name, x => x.MapFrom(cbm => cbm.Brand));
        }
    }
}
