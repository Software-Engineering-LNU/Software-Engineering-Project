using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly EmployeestDbContext _db = new EmployeestDbContext();


    public async Task<List<Project>> getListOfProjectsByUserId(int id)
    {
        HashSet<int> projectIds = new HashSet<int>();
        foreach (var projectMember in _db.ProjectMembers.Where(x => x.UserId == id))
        {
            projectIds.Add(projectMember.ProjectId);
        }
        List<Project> projects = _db.Projects.Where(x => projectIds.Contains(x.Id)).ToList();

        return projects;
    }


    public async Task<Project> GetProjectById(int id)
    {
        return await _db.Projects.SingleAsync(x => x.Id == id);
    }
}
