using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<int> Contain(string email, string password);
        Task<User> GetUser(int id);
        Task AddUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User>GetUserByEmail(string email);
        Task UpdateUser(User user);
    }
}
