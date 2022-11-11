using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class PositionPermission
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public Position Position { get; set; } 
    }
}
