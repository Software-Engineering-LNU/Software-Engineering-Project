using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Team
    {
        public Team()
        {
            Tasks = new HashSet<Task>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
