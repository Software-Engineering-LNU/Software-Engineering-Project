using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class ProjectMember
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }
        public double Salary { get; set; }
        public Position Position { get; set; }
        public Project Project { get; set; } 
        public User User { get; set; }
    }
}
