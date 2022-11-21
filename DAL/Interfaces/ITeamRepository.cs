using DAL.Entities;

namespace DAL.Interfaces;

public interface ITeamRepository
{
    Task<List<User>> getTeamByUserId(int id);
}