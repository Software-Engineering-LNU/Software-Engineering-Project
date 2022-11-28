using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class TeamService: ITeamService
{
    public Task<List<User>> getTeamMembersByUserId(int id)
    {
        TeamRepository teamRepository = new TeamRepository();
        return teamRepository.getTeamByUserId(id);
    }
}