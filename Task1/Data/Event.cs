using System;
using System.Collections.Generic;

namespace Data
{
    public class Event
    {
        public Event(State state, User user, DateTime time)
        {
            State = state;
            User = user;
            Time = time;
        }

        public State State
        { get; set; }

        public User User
        { get; set; }

        public DateTime Time
        { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Event currentEvent &&
                   this.User.Username == currentEvent.User.Username &&
                   this.Time == currentEvent.Time;
        }

        public override int GetHashCode()
        {
            int hashCode = 1820166108;
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + Time.GetHashCode();
            return hashCode;
        }
    }
}
