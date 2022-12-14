using DAL.Entities;
using EmployeestSeed.EntityFactories.Interfaces;

namespace EmployeestSeed.Data
{
    public interface IUnitOfWork
    {
        public IDbEntityFactory<User> UserFactory { get; }
        public IDbEntityFactory<TeamMember> TeamMemberFactory { get; }
        public IDbEntityFactory<Team> TeamFactory { get; }
        public IDbEntityFactory<DAL.Entities.Task> TaskFactory { get; }
        public IDbEntityFactory<ProjectMember> ProjectMemberFactory { get; }
        public IDbEntityFactory<Project> ProjectFactory { get; }
        public IDbEntityFactory<PositionPermission> PositionPermissionFactory { get; }
        public IDbEntityFactory<Position> PositionFactory { get; }
        public IDbEntityFactory<Permission> PermissionFactory { get; }
        public IDbEntityFactory<EventMember> EventMemberFactory { get; }
        public IDbEntityFactory<Event> EventFactory { get; }
    }
}
