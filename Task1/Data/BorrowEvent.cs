using System;

namespace Data
{
    public class BorrowEvent : AbstractEvent
    {
        public BorrowEvent(IState state, IUser user, DateTime time) : base(state, user, time)
        {
            State = state;
            User = user;
            Time = time;
            Perform();
        }

        protected override void Perform()
        {
            if (!(State.IsBorrowed))
            {
                State.IsBorrowed = true;
            }
            else
            {
                throw new Exception("A borrowed book can not be borrowed");
            }
        }
    }
}
