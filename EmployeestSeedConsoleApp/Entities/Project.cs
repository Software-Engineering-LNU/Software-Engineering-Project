
namespace EmployeestSeedConsoleApp.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Desctiption { get; set; }
        public User User { get; set; }
    }
}
