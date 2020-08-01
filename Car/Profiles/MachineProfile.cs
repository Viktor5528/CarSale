using AutoMapper;
using Car.Entity;
using DataLayer.Entity.EntityViewModel;

namespace Car.Profiles
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            CreateMap<CreateMachineViewModel, Machine>();
        }
    }
}
