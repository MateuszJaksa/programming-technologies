using System;

namespace Data
{
    public class ReturnEvent : AbstractEvent
    {
        public ReturnEvent(State state, User user, DateTime time) : base(state, user, time)
        {
            State = state;
            User = user;
            Time = time;
            Perform();
        }

        public override void Perform()
        {
            if (State.IsBorrowed)
            {
                State.IsBorrowed = false;
            }
            else
            {
                throw new Exception("A not borrowed book can not be returned");
            }
        }
    }
}
