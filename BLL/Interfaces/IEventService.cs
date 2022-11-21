using DAL.Entities;

namespace BLL.Interfaces;

public interface IEventService
{
    Task<List<Event>> getEventsByUserId(int id);
}