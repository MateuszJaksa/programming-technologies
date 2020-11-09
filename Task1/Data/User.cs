using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   this.Username == user.Username;
        }

        public override int GetHashCode()
        {
            return 404878561 + EqualityComparer<string>.Default.GetHashCode(Username);
        }
    }
}
