using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EmployeestDbContext _db = new EmployeestDbContext();
    public async Task<List<Event>> getListOfEventsByUserId(int id)
    {
        HashSet<int> eventIds = new HashSet<int>();
        foreach (var eventMember in _db.EventMembers.Where(x => x.UserId == id))
        {
            eventIds.Add(eventMember.EventId);
        }

        List<Event> events = _db.Events.Where(x => eventIds.Contains(x.Id)).ToList();

        return events;
    }
}