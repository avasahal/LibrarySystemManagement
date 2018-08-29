using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Book : AbstractItem
    {
        public BookCategory SubCategory { get; set; }
        public string _author { get; set; }

        public Book(BookCategory subCategory, string itemName, string author, string publisher, DateTime datePrint, int copyNumber)
            : base( LibraryCategory.Book, itemName, datePrint, copyNumber, publisher)
        {
            SubCategory = subCategory;
            _author = author;
        }

        //public List<Book> bookList = new List<Book>();
        
    }
}
