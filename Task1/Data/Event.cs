using System;

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

        public override string ToString()
        {
            return User.ToString() + " borrowed " + State.ToString() + " on " + Time;
        }
    }
}
