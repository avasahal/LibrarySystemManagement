using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public static class UsersCollection
    {
        public static List<User> UsersList = new List<User>();

        public static void InitiateUser()
        {
            UsersList.Add(new User("avazzle", "111", UserType.Admin));
            UsersList.Add(new User("ne2s","222", UserType.User));
            UsersList.Add(new User("", "", UserType.Guest));
        }

        public static User CreateNewUser(string firstname, string lastname, string username, string email, string password, UserType userType)
        {
            User newUser = new User(username,password, userType);
            return newUser;
        }

        public static void AddUser(User newUser)
        {
            //newItem.isbn = Guid.NewGuid();
            //itemList.Add(newItem);
            UsersList.Add(newUser);
        }
    }
}
