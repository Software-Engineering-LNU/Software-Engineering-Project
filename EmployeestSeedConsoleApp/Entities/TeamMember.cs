using System;
using System.Collections.Generic;

namespace EmployeestSeedConsoleApp
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
    }
}
