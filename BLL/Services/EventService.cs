using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class EventService: IEventService
{
    public async Task<List<Event>> getEventsByUserId(int id)
    {
        EventRepository eventRepository = new EventRepository();

        return eventRepository.getListOfEventsByUserId(id).Result;
    }
}