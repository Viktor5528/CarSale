using Car.Enums;
using System.Collections.Generic;


namespace Car.Entity
{
    public class Machine
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int BodyId { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public EngineType EngineType { get; set; }
    }
}
