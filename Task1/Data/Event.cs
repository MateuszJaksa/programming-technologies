using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Event
    {
        private State _state;
        private User _user;
        private DateTime _time;

        public Event(State state, User user, DateTime time)
        {
            this._state = state;
            this._user = user;
            this._time = time;
        }

        public State State
        {
            get => _state;
            set => this._state = value;
        }

        public User User
        {
            get => _user;
            set => this._user = value;
        }

        public DateTime Time
        {
            get => _time;
            set => this._time = value;
        }

        public override string ToString()
        {
            return _user.ToString() + " borrowed " + _state.ToString() + " on " + _time;
        }
    }
}
