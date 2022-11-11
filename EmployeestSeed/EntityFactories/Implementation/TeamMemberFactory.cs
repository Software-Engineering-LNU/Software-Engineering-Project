using DAL.Data;
using DAL.Entities;
using EmployeestSeed.EntityFactories.Interfaces;

namespace EmployeestSeed.EntityFactories.Implementation
{
    public sealed class TeamMemberFactory : IDbEntityFactory<TeamMember>
    {
        public TeamMember CreateEntity()
        {
            TeamMember teamMember = new TeamMember();

            teamMember.UserId = GetRandomUserId();
            teamMember.TeamId = GetRandomTeamId();

            return teamMember;
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

        private int GetRandomTeamId()
        {
            using (var db = new EmployeestDbContext())
            {
                List<Team> teams = db.Teams.Select(team => team).ToList();
                Random random = new Random();

                return teams[random.Next(teams.Count)].Id;
            }
        }
    }
}
