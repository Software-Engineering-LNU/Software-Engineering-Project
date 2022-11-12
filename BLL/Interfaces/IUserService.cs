using DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> Login(string email, string password);
    }
}
