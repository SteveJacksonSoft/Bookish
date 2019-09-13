namespace Bookish.DataAccess.Models {
    public class LoanFromDB {
        public int Id { get; }
        public int BookId { get; }
        public int BorrowerId { get; }
        public string DateBorrowed { get; }
        public string DateDue { get; }
        public bool Returned { get;  }
    }
}