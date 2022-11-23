using BLL.Models;
using DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<int> Login(string email, string password);
        Task<int> Register(string email, string password, string fullname, string phoneNumber, bool isBusinessOwner);
        Task<User> GetUser(int id);
        Task<List<UsersListModel>> GetUsersList();
    }
}
