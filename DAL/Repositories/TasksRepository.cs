using DAL.Data;
using DAL.Interfaces;
using Task = DAL.Entities.Task;

namespace DAL.Repositories;

public class TasksRepository : ITaskRepository
{
    private readonly EmployeestDbContext _db = new EmployeestDbContext();
    
    public async Task<List<Task>> getTasksByUserId(int userId)
    {
        var tasks = _db.Tasks.Where(x => x.UserId == userId).ToList();

        return tasks;
    }
}