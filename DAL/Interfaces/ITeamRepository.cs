using DAL.Entities;
using Npgsql.PostgresTypes;

namespace DAL.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<User>> getTeamByUserId(int id);
        Task<Team> GetTeamByProjectId(int projectId);
    }
}
