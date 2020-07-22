using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public int MachineId { get; set; }
    }
}
