using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class ProjectService : IProjectService
{
    public Task<List<Project>> getProjectsByUserId(int id)
    {
        ProjectRepository projectRepository = new ProjectRepository();

        return projectRepository.getListOfProjectsByUserId(id);
    }
}