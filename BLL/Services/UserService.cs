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


        public async Task<List<EmployeesListModel>> GetEmployeesList()
        {
            List<EmployeesListModel> usersList = new List<EmployeesListModel>();

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
                        usersList.Add(new EmployeesListModel
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

            return usersList;
        }


        public async Task<List<TeamListModel>> GetTeamListByUserId(int userId)
        {
            List<TeamListModel> team = new List<TeamListModel>();

            List<User> users = await _unitOfWork.TeamRepository.getTeamByUserId(userId);
            foreach (var user in users)
            {
                List<ProjectMember> projectMembers = await _unitOfWork.ProjectMemberRepository.GetProjectMemberByUserId(user.Id);
                foreach (var projectMember in projectMembers)
                {
                    Project project = await _unitOfWork.ProjectRepository.GetProjectById(projectMember.ProjectId);
                    Position position = await _unitOfWork.PositionRepository.GetPositionById(projectMember.PositionId);

                    if (project is not null && team is not null && position is not null)
                    {
                        team.Add(new TeamListModel
                        {
                            Fullname = user.FullName,
                            Email = user.Email,
                            Position = position.Name,
                            Project = project.Name
                        });
                    }
                }
            }

            return team;
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.GetUserByEmail(email);
        }

        public async System.Threading.Tasks.Task UpdateUser(User user)
        {
            await _unitOfWork.UserRepository.UpdateUser(user);
        }
    }
}
