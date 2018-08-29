using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLib
{
    public abstract class AbstractItem
    {

        #region _fields
        public Guid _isbn {get;set;}
        public LibraryCategory Category { get; set; }
        public string _itemName {get;set;}
        public DateTime _datePrint{get;set;}
        public int _copyNumber{get;set;}
        public string _publisher {get;set;}
        private bool _isBorrowed;
        public User CurrentBorrower { get; set; }
        
        #endregion

        #region Constractors
        public AbstractItem(LibraryCategory category, string itemName, DateTime datePrint, int copyNumber, string publisher)
        {
            isbn = Guid.NewGuid(); 
            Category = category;
            _itemName = itemName;
            _datePrint = datePrint;
            _copyNumber = copyNumber;
            _publisher = publisher;
            IsBorrowed = false;
        }
        #endregion

        #region Properties

        public bool IsBorrowed
        {
            get { return _isBorrowed; }
            set
            {
                if (value == false) CurrentBorrower = null;
                _isBorrowed = value;
            }
        }
        public Guid isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }
        public LibraryCategory category
        {
            get { return Category; }
            set { Category = value; }
        }
        public string itemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        public DateTime datePrint
        {
            get { return _datePrint; }
            set { _datePrint = value; }
        }
        public int copyNumber
        {
            get { return _copyNumber; }
            set { _copyNumber = value; }
        }
        public string publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        #endregion

       // public string publisher { get; set; }
    }
}
