using System;

namespace Data
{
    public class User
    {
        public User(string userName)
        {
            Username = userName;
        }

        public string Username
        { get; set; }

        public override string ToString()
        {
            return "Our user " + Username;
        }
    }
}
