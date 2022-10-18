using System;
using System.Collections.Generic;

namespace EmployeestSeedConsoleApp
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Estimation { get; set; }
        public string Status { get; set; } 
        public int StoryPoints { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public Team Team { get; set; }
        public User User { get; set; } 
    }
}
