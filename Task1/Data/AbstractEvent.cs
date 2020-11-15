using System;
using System.Collections.Generic;

namespace Data
{
    public abstract class AbstractEvent
    {
        public AbstractEvent(State state, User user, DateTime time)
        {
            State = state;
            User = user;
            Time = time;
        }

        public abstract void Perform();

        public State State
        { get; set; }

        public User User
        { get; set; }

        public DateTime Time
        { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AbstractEvent currentEvent &&
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

        public override string ToString()
        {
            return $"The event happened on {Time.Day}.{Time.Month} at {Time.Hour}:{Time.Minute}:{Time.Second}";
        }
    }
}
