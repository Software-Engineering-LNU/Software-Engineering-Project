using DAL.Data;
using Microsoft.Extensions.Configuration;

namespace EmployeestSeed.Data
{
    public static class EmployeestSeedData
    {
        private static readonly IUnitOfWork _unitOfWork = new UnitOfWork();


        public static void SeedData(int count)
        {
            using (EmployeestDbContext db = new EmployeestDbContext())
            {
                for (int i = 0; i < count; i++)
                {
                    db.Positions.Add(_unitOfWork.PositionFactory.CreateEntity());
                    db.Permissions.Add(_unitOfWork.PermissionFactory.CreateEntity());
                    db.Events.Add(_unitOfWork.EventFactory.CreateEntity());
                    db.Users.Add(_unitOfWork.UserFactory.CreateEntity());

                }
                db.SaveChanges();


                for (int i = 0; i < count; i++)
                {
                    db.Projects.Add(_unitOfWork.ProjectFactory.CreateEntity());
                    db.EventMembers.Add(_unitOfWork.EventMemberFactory.CreateEntity());
                    db.PositionPermissions.Add(_unitOfWork.PositionPermissionFactory.CreateEntity());
                }
                db.SaveChanges();


                for(int i = 0; i<count; i++)
                {
                    db.Teams.Add(_unitOfWork.TeamFactory.CreateEntity());
                    db.ProjectMembers.Add(_unitOfWork.ProjectMemberFactory.CreateEntity());
                }
                db.SaveChanges();


                for(int i = 0; i<count; i++)
                {
                    db.Tasks.Add(_unitOfWork.TaskFactory.CreateEntity());
                    db.TeamMembers.Add(_unitOfWork.TeamMemberFactory.CreateEntity());
                }
                db.SaveChanges();


            }
        }
    }
}
