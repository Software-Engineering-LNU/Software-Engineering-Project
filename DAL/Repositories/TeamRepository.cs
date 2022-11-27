using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly EmployeestDbContext _db = new EmployeestDbContext();

    public async Task<List<User>> getTeamByUserId(int id)
    {
        HashSet<int> teamIds = new HashSet<int>();
        foreach (var projectMember in _db.TeamMembers.Where(x => x.UserId == id))
        {
            teamIds.Add(projectMember.TeamId);
        }
        List<Team> teams = _db.Teams.Where(x => teamIds.Contains(x.Id)).ToList();
        List<User> users = new List<User>();

        UserRepository userRepository = new UserRepository();

        foreach (var currentTeam in teams)
        {
            foreach (var projectMember in _db.TeamMembers.Where(x => x.TeamId == currentTeam.Id))
            {
                users.Add(await userRepository.GetUser(projectMember.UserId));
            }
        }

        return users;
    }
}