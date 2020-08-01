using Car.Enums;

namespace DataLayer.Entity.EntityViewModel
{
    public class CreateMachineViewModel
    {
        public int BrandId { get; set; }
        public BodyType BodyType { get; set; }
        public EngineType EngineType { get; set; }
    }
}
