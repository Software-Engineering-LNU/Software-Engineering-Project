namespace BLL.Interfaces;

public interface ITaskService
{
    Task<List<DAL.Entities.Task>> getTasksByUserId(int userId);
}