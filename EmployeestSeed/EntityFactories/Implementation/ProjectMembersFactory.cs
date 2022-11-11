using DAL.Data;
using DAL.Entities;
using EmployeestSeed.EntityFactories.Interfaces;

namespace EmployeestSeed.EntityFactories.Implementation
{
    public sealed class ProjectMembersFactory : IDbEntityFactory<ProjectMember>
    {
        public ProjectMember CreateEntity()
        {
            ProjectMember projectMember = new ProjectMember();

            projectMember.UserId = GetRandomUserId();
            projectMember.ProjectId = GetRandomProjectId();
            projectMember.PositionId = GetRandomPositionId();
            projectMember.Salary = GenerateSalary();

            return projectMember;
        }

        private int GetRandomUserId()
        {
            using (var db = new EmployeestDbContext())
            {
                List<User> users = db.Users.Select(user => user).ToList();
                Random random = new Random();

                return users[random.Next(users.Count)].Id;
            }
        }

        private int GetRandomProjectId()
        {
            using (var db = new EmployeestDbContext())
            {
                List<Project> projects = db.Projects.Select(project => project).ToList();
                Random random = new Random();

                return projects[random.Next(projects.Count)].Id;
            }
        }

        private int GetRandomPositionId()
        {
            using (var db = new EmployeestDbContext())
            {
                List<Position> positions = db.Positions.Select(position => position).ToList();
                Random random = new Random();

                return positions[random.Next(positions.Count)].Id;
            }
        }

        private double GenerateSalary()
        {
            Random random = new Random();

            return random.Next(3, 10) * 1000;
        }
    }
}
