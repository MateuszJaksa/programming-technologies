using System;
using System.Collections.Generic;

namespace Data
{
    public abstract class AbstractEvent
    {
        public AbstractEvent(IState state, IUser user, DateTime time)
        {
            State = state;
            User = user;
            Time = time;
        }

        protected abstract void Perform();

        public IState State
        { get; set; }

        public IUser User
        { get; set; }

        public DateTime Time
        { get; set; }



        public override string ToString()
        {
            return $"The event happened on {Time.Day}.{Time.Month} at {Time.Hour}:{Time.Minute}:{Time.Second}";
        }

        public override bool Equals(object obj)
        {
            return obj is AbstractEvent currEvent &&
                   EqualityComparer<IUser>.Default.Equals(User, currEvent.User) &&
                   Time == currEvent.Time;
        }

        public override int GetHashCode()
        {
            int hashCode = 1125830374;
            hashCode = hashCode * -1521134295 + EqualityComparer<IUser>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + Time.GetHashCode();
            return hashCode;
        }
    }
}
