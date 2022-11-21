using DAL.Entities;

namespace DAL.Interfaces;

public interface IProjectRepository
{
    Task<List<Project>> getListOfProjectsByUserId(int id);
}