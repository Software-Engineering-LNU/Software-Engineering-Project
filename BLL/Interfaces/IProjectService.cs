using DAL.Entities;

namespace BLL.Interfaces;

public interface IProjectService
{
    Task<List<Project>> getProjectsByUserId(int id);
}