using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class EventMember
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }
    }
}
