using BLL.Interfaces;
using DAL.Entities;
using DAL.Data;
using DAL.Interfaces;
using BLL.Models;

namespace BLL.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();


        public async Task<int> Login(string email, string password)
        {
            int userId = await _unitOfWork.UserRepository.Contain(email, password);
            return userId;
        }


        public async Task<int> Register(string email, string password, string fullname, string phoneNumber, bool isBusinessOwner)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;
            user.FullName = fullname;
            user.PhoneNumber = phoneNumber;
            user.IsBusinessOwner = isBusinessOwner;
            await _unitOfWork.UserRepository.AddUser(user);
            int userId = await _unitOfWork.UserRepository.Contain(email, password);

            return userId;
        }


        public async Task<User> GetUser(int id)
        {
            return await _unitOfWork.UserRepository.GetUser(id);
        }

        public async Task<List<UsersListModel>> GetUsersList()
        {
            List<UsersListModel> usersList = new List<UsersListModel>();

            //try
            //{
            List<User> users = await _unitOfWork.UserRepository.GetAllUsers();
            foreach (var user in users)
            {
                List<ProjectMember> projectMembers = await _unitOfWork.ProjectMemberRepository.GetProjectMemberByUserId(user.Id);
                foreach (var projectMember in projectMembers)
                {
                    Project project = await _unitOfWork.ProjectRepository.GetProjectById(projectMember.ProjectId);
                    Team team = await _unitOfWork.TeamRepository.GetTeamByProjectId(project.Id);
                    Position position = await _unitOfWork.PositionRepository.GetPositionById(projectMember.PositionId);

                    if (project is not null && team is not null && position is not null)
                    {
                        usersList.Add(new UsersListModel
                        {
                            Fullname = user.FullName,
                            Email = user.Email,
                            Project = project.Name,
                            Team = team.Name,
                            Position = position.Name,
                            Salary = projectMember.Salary
                        });
                    }
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //}

            return usersList;
        }
    }
}
