using EmployeestSeedConsoleApp.Interfaces;

namespace EmployeestSeedConsoleApp.EntityFactories
{
    public sealed class EventFactory : IDbEntityFactory<Event>
    {
        private static int EntitiesCounter = 0;

        public Event CreateEntity()
        {
            Event ev = new Event();

            ev.Id = GenerateId();
            ev.Name = GenerateName();
            ev.Date = GenerateDate();
            ev.StartTime = GenerateStartTime();
            ev.EndTime = GenerateEndTime();

            return ev;
        }

        private int GenerateId()
        {
            return ++EntitiesCounter;
        }

        private string GenerateName()
        {
            return "TestName" + Convert.ToString(EntitiesCounter);
        }

        private DateOnly GenerateDate()
        {
            var date = new DateOnly();

            Random random = new Random();
            int year = random.Next(2020, 2025);
            int month = random.Next(1, 12);
            int day = random.Next(1, 28);

            return new DateOnly(year, month, day);
        }

        private TimeOnly GenerateStartTime()
        {
            Random random = new Random();

            int hour = random.Next(8, 12);
            int minute = random.Next(0, 60);

            return new TimeOnly(hour, minute);
        }

        private TimeOnly GenerateEndTime()
        {
            Random random = new Random();

            int hour = random.Next(13, 15);
            int minute = random.Next(0, 60);

            return new TimeOnly(hour, minute);
        }
    }
}

