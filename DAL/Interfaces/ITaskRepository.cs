namespace DAL.Interfaces;

public interface ITaskRepository
{
    Task<List<DAL.Entities.Task>> getTasksByUserId(int userId);
}