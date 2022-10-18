using System;
using System.Collections.Generic;

namespace EmployeestSeedConsoleApp
{
    public class Project
    {
        public Project()
        {
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; } 
        public ICollection<Team> Teams { get; set; }
    }
}
