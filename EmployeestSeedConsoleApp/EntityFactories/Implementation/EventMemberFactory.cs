using EmployeestSeedConsoleApp.Interfaces;

namespace EmployeestSeedConsoleApp.EntityFactories
{
    public sealed class EventMembersFactory : IDbEntityFactory<EventMember>
    {
        public EventMember CreateEntity()
        {
            EventMember eventMember = new EventMember();

            eventMember.UserId = GetRandomUserId();
            eventMember.EventId = GetRandomEventId();

            return eventMember;
        }

        private int GetRandomUserId()
        {
            using (var db = new EmployeestDbContext(Program.Configuration))
            {
                List<User> users = db.Users.Select(user => user).ToList();
                Random random = new Random();

                return users[random.Next(users.Count)].Id;
            }
        }

        private int GetRandomEventId()
        {
            using (var db = new EmployeestDbContext(Program.Configuration))
            {
                List<Event> events = db.Events.Select(ev => ev).ToList();
                Random random = new Random();

                return events[random.Next(events.Count)].Id;
            }
        }
    }
}
