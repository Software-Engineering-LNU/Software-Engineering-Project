using DAL.Entities;

namespace BLL.Interfaces;

public interface ITeamService
{
    Task<List<User>> getTeamMembersByUserId(int id);
}