
namespace DAL.Entities
{
    public class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
            Tasks = new HashSet<Task>();
        }
        public int Id { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string FullName { get; set; } 
        public string PhoneNumber { get; set; }
        public bool IsBusinessOwner { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
