using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entity.EntityViewModel
{
    public class CreateCommentViewModel
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public int MachineId { get; set; }
    }
}
