using DAL.Repositories;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IPositionRepository PositionRepository { get; }
        public IUserRepository UserRepository { get; }
        public IProjectMemberRepository ProjectMemberRepository { get; }
        public ITeamRepository TeamRepository { get; }
        public IProjectRepository ProjectRepository { get; }
    }
}
