using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public sealed class ProjectMemberRepository : IProjectMemberRepository
    {
        private readonly EmployeestDbContext _db = new EmployeestDbContext();


        public async Task<List<ProjectMember>> GetProjectMemberByUserId(int userId)
        {
            return await _db.ProjectMembers.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
