namespace EmployeestSeedConsoleApp.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int Estimation { get; set; }
        //public  Status!

        public int StoryPoints { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
    }
}
