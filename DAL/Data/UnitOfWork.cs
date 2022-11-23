using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPositionRepository PositionRepository => new PositionRepository();
        public IUserRepository UserRepository => new UserRepository();
        public IProjectMemberRepository ProjectMemberRepository => new ProjectMemberRepository();
        public ITeamRepository TeamRepository => new TeamRepository();
        public IProjectRepository ProjectRepository => new ProjectRepository();
    }
}
