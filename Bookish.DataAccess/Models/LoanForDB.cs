namespace Bookish.DataAccess.Models {
    public class LoanForDB {
        public int BookId { get; }
        public int BorrowerId { get; }
        public string DateBorrowed { get; }
        public string DateDue { get; }
        public bool Returned { get;  }
        
        public LoanForDB(int bookId, int borrowerId, string dateBorrowed, string dateDue, bool returned) {
            BookId = bookId;
            BorrowerId = borrowerId;
            DateBorrowed = dateBorrowed;
            DateDue = dateDue;
            Returned = returned;
        }
    }
}