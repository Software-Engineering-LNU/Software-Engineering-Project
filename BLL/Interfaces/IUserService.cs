using DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<int> Login(string email, string password);
        Task<string> GetFullName(int id);
    }
}
