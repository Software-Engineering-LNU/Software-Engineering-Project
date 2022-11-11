using DAL.Data;
using DAL.Entities;
using EmployeestSeed.EntityFactories.Interfaces;

namespace EmployeestSeed.EntityFactories.Implementation
{
    public sealed class ProjectFactory : IDbEntityFactory<Project>
    {
        private static int entitiesCounter = 0;

        public Project CreateEntity()
        {
            Project project = new Project();

            project.Id = GenerateId();
            project.Name = GenerateName();
            project.Description = GenerateDescription();
            project.OwnerId = GetRandomOwnerId();

            return project;
        }

        private int GenerateId()
        {
            return ++entitiesCounter;
        }

        private string GenerateName()
        {
            return "Test Name " + entitiesCounter.ToString();
        }

        private string GenerateDescription()
        {
            return "Test description for \'" + GenerateName() + "\' project";
        }

        private int GetRandomOwnerId()
        {
            using (var db = new EmployeestDbContext())
            {
                List<User> users = db.Users.Where(user => user.IsBusinessOwner == true).ToList();
                Random random = new Random();

                User randomUser = users[random.Next(users.Count)];


                return randomUser.Id;
            }
        }
    }
}
