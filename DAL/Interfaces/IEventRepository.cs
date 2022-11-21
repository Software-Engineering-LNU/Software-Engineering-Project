using DAL.Entities;

namespace DAL.Interfaces;

public interface IEventRepository
{
    Task<List<Event>> getListOfEventsByUserId(int id);
}