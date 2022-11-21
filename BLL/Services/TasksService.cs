using BLL.Interfaces;
using DAL.Repositories;
using Task = DAL.Entities.Task;

namespace BLL.Services;

public class TasksService: ITaskService
{
    public Task<List<Task>> getTasksByUserId(int userId)
    {
        TasksRepository tasksRepository = new TasksRepository();
        return tasksRepository.getTasksByUserId(userId);
    }
}