using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BorrowEvent : AbstractEvent
    {
        public BorrowEvent(State state, User user, DateTime time) : base(state, user, time)
        {
            State = state;
            User = user;
            Time = time;
            Perform();
        }

        public override void Perform()
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
