using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Journal : AbstractItem
    {
        public JournalCategory SubCategory { get; set; }
        

        public Journal(JournalCategory subCategory, string itemName, string publisher, DateTime datePrint, int copyNumber)
            : base(LibraryCategory.Journal, itemName, datePrint, copyNumber, publisher)
        {

        }
    }
}
