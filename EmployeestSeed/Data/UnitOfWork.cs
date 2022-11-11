using DAL.Entities;
using EmployeestSeed.EntityFactories.Implementation;
using EmployeestSeed.EntityFactories.Interfaces;

namespace EmployeestSeed.Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public IDbEntityFactory<User> UserFactory => new UserFactory();

        public IDbEntityFactory<TeamMember> TeamMemberFactory => new TeamMemberFactory();

        public IDbEntityFactory<Team> TeamFactory => new TeamFactory();

        public IDbEntityFactory<DAL.Entities.Task> TaskFactory => new EntityFactories.Implementation.TaskFactory();

        public IDbEntityFactory<ProjectMember> ProjectMemberFactory => new ProjectMembersFactory();

        public IDbEntityFactory<Project> ProjectFactory => new ProjectFactory();

        public IDbEntityFactory<PositionPermission> PositionPermissionFactory => new PositionPermissionFactory();

        public IDbEntityFactory<Position> PositionFactory => new PositionFactory();

        public IDbEntityFactory<Permission> PermissionFactory => new PermissionFactory();

        public IDbEntityFactory<EventMember> EventMemberFactory => new EventMembersFactory();

        public IDbEntityFactory<Event> EventFactory => new EventFactory();
    }
}
