using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookLib
{
    public class User
    {
        public string FirstName;
        public string LastName;
        public string Username { get; set; }
        public string Email;
        public string Password { get; set; }
        public UserType UserType { get; set; }

        public User(string username, string password, UserType userType)
        {
            
            Username = username;
            
            Password = password;
            UserType = userType;
        }

        internal bool SetUserAsManager()
        {
            return UserType == UserType.Admin;
        }
        public bool IsCorrectPassword(string password)
        {
            return (Password == password);
        }


    }
}
