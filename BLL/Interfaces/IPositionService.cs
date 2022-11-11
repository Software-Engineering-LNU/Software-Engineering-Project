using DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace BLL.Interfaces
{
    public interface IPositionService
    {
        Task Add(Position position);
    }
}
