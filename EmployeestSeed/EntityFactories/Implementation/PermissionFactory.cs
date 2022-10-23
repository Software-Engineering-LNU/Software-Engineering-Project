using DAL.Entities;
using EmployeestSeed.EntityFactories.Interfaces;

namespace EmployeestSeed.EntityFactories.Implementation
{
    public sealed class PermissionFactory : IDbEntityFactory<Permission>
    {
        static int EntitiesCounter = 0;

        public Permission CreateEntity()
        {
            Permission permission = new Permission();

            permission.Id = GenerateId();
            permission.Name = GenerateName();

            return permission;
        }

        private int GenerateId()
        {
            return ++EntitiesCounter;
        }

        private string GenerateName()
        {
            return "TestName" + Convert.ToString(EntitiesCounter);
        }
    }
}
