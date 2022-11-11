using DAL.Data;
using DAL.Entities;
using EmployeestSeed.EntityFactories.Interfaces;

namespace EmployeestSeed.EntityFactories.Implementation
{
    internal class PositionPermissionFactory : IDbEntityFactory<PositionPermission>
    {
        public PositionPermission CreateEntity()
        {
            PositionPermission positionPermission = new PositionPermission();

            positionPermission.PositionId = GetRandomPositionId();
            positionPermission.PermissionId = GetRandomPermissionId();

            return positionPermission;
        }

        private int GetRandomPositionId()
        {
            using (var db = new EmployeestDbContext())
            {
                List<Position> positions = db.Positions.Select(position => position).ToList();
                Random random = new Random();

                return positions[random.Next(positions.Count)].Id;
            }
        }

        private int GetRandomPermissionId()
        {
            using (var db = new EmployeestDbContext())
            {
                List<Permission> permissions = db.Permissions.Select(permission => permission).ToList();
                Random random = new Random();

                return permissions[random.Next(permissions.Count)].Id;
            }
        }
    }
}