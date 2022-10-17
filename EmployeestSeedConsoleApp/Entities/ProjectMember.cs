namespace EmployeestSeedConsoleApp.Entities
{
    public class ProjectMember
    {
        public Project Project { get; set; }
        public User User { get; set; }
        public Position Position { get; set; }
        public double Salary { get; set; }

    }
}
