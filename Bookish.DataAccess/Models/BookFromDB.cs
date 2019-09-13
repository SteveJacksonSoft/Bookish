using System.Collections.Generic;
using System.Linq;

namespace Bookish.DataAccess.Models {
    public class BookFromDB {
        public int Id;
        public string Isbn;
        public string Title;
        public string Author;

        public bool IsAvailable(IEnumerable<LoanFromDB> loans) {
            return !loans.Any(loan => loan.BookId.Equals(this.Id) && loan.Returned == false);
        }
    }
}