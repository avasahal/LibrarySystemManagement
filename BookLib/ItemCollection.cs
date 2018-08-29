using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public static class ItemCollection 
    {
        public static List<AbstractItem> itemList = new List<AbstractItem>();

        public static void InitiateData()
        {
            itemList.Add(new Book(BookCategory.Fiction, "Harry Potter", "J.K. Rowling","The Publisher", DateTime.Parse("1/12/2000"),10));
            itemList.Add(new Journal(JournalCategory.Gossip,  "Latest Gossip", "Publishers", DateTime.Now, 20));
            itemList.Add(new Book(BookCategory.History, "America", "Americans", "Pub", DateTime.Parse("02/03/1770"),5));
        }


        public static AbstractItem CreateBookItem(BookCategory bookCategory, string itemName, string author, string publisher, DateTime datePrint, int copyNumber)
        {
            AbstractItem newItem = new Book(bookCategory, itemName, author, publisher, datePrint, copyNumber);
            return newItem;
        }

        public static AbstractItem CreateJournalItem(JournalCategory journalCategory, string itemName, string publisher, DateTime datePrint, int copyNumber)
        {
            AbstractItem newItem = new Journal(journalCategory, itemName, publisher, datePrint, copyNumber);
            return newItem;
        }

        public static void AddItem(AbstractItem newItem)
        {
            newItem.isbn = Guid.NewGuid();
            itemList.Add(newItem);
        }

       
        public static List<AbstractItem> Search(string itemName, string publisher)
        {
            var foundedItems = (from item in itemList
                                where item.itemName == itemName || item._publisher == publisher
                                select item).ToList();
            return foundedItems;

        }

        public static void RemoveByID(Guid isbn)
        {
            if (itemList !=null)
            {
                itemList.RemoveAll(item => item.isbn == isbn);
            }
        }

        public static bool BorrowItem(AbstractItem item)
        {
            if (item.IsBorrowed)
                return false;
            else
                return (item.IsBorrowed = true);
        }

        public static void ReturnItem(AbstractItem item)
        {
            item.IsBorrowed = false;
        }

    }
}
