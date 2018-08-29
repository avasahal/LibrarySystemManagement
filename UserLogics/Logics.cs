using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UserLogics
{
   
    public class Logics
    {
        public User CurrentUser { get; set; }
        public AbstractItem SelectedItem { get; set; }

        //I created an instance because without it, when running the program, it keeps getting me out of the program
        //when entering an action. Now when I make an action(like entering username and password) it makes me stay on it.
        public static Logics Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logics();
                    instance.InitialData();
                }
                return instance;
            }
        }
        private static Logics instance;

        public void InitialData()
        {
            UsersCollection.InitiateUser();
            ItemCollection.InitiateData();
        }

        public void LoginUser(string username, string password)
        {
            CurrentUser = UsersCollection.UsersList.
                Find(u => u.Username == username && u.IsCorrectPassword(password));
        }

        public bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        public void LogOut()
        {
            CurrentUser = null;
        }

        public bool IsAdmin()
        {
            return CurrentUser.UserType == UserType.Admin;
        }
        public bool IsUser()
        {
            return CurrentUser.UserType == UserType.User;
        }
        public bool IsGuest()
        {
            return CurrentUser.UserType == UserType.Guest;
        }

        public IEnumerable<object> GetAllLibraryItems()
        {
            IEnumerable<object> libraryCollection = ItemCollection.itemList.Select(item => (object)item);
            return libraryCollection;
        }

        public IEnumerable<object> SelectItem(LibraryCategory category, string itemName, string authorName, DateTime? datePrint)
        {
            IEnumerable<object> filteredList = ItemCollection.itemList.
                FindAll(item => IsMatchItem(category, itemName, authorName, datePrint, item));
            return filteredList;
        }

        public bool IsMatchItem(LibraryCategory category, string itemName, string authorName, DateTime? datePrint, AbstractItem item)
        {
            return ((item.category == category) 
                && (item.itemName == itemName || "" == itemName)
                && (item.datePrint == datePrint || DateTime.MinValue == datePrint));
        }

        public void addBookItem(BookCategory bookCategory, string itemName, string author, string publisher, DateTime datePrint, int copyNumber)
        {
            AbstractItem newItem = ItemCollection.CreateBookItem(bookCategory, itemName, author, publisher, datePrint, copyNumber);
            ItemCollection.AddItem(newItem);
        }

        public void addJournalItem(JournalCategory journalCategory, string itemName, string publisher, DateTime datePrint, int copyNumber)
        {
            AbstractItem newItem = ItemCollection.CreateJournalItem(journalCategory, itemName, publisher, datePrint, copyNumber);
            ItemCollection.AddItem(newItem);
        }

        public void removeItem(AbstractItem item)
        {
            ItemCollection.RemoveByID(item.isbn);
        }

        public void addNewUser(string firstname, string lastname,string username, string email, string password, UserType userType)
        {
            User newUser = UsersCollection.CreateNewUser(firstname, lastname, email, username, password, userType);
            UsersCollection.AddUser(newUser);

        }

        public void BorrowItem(AbstractItem item)
        {
            ItemCollection.BorrowItem(item);
            item.CurrentBorrower = CurrentUser;
        }

        public void ReturnItem(AbstractItem item)
        {
            if (item.CurrentBorrower == CurrentUser)
            {
                ItemCollection.ReturnItem(item);
            }
        }

    }
      

}
