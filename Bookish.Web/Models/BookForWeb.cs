using System.Collections.Generic;
using System.Linq;
using Bookish.DataAccess.Models;

namespace Bookish.Web.Models {
    public class BookForWeb {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumCopiesOwned { get; set; }
        public int NumCopiesAvailable { get; set; }

        public BookForWeb(string isbn, string title, string author, int numCopiesOwned, int numCopiesAvailable) {
            Isbn = isbn;
            Title = title;
            Author = author;
            NumCopiesOwned = numCopiesOwned;
            NumCopiesAvailable = numCopiesAvailable;
        }

        public static IEnumerable<BookForWeb> GenerateWebBookEnumerableFromDBRecords(
            IEnumerable<BookFromDB> books,
            IEnumerable<LoanFromDB> loans
        ) {
            return books.GroupBy(book => book.Isbn)
                .Select(bookGrouping => {
                    BookFromDB firstBookInGrouping = bookGrouping.First();
                    return new BookForWeb(
                        firstBookInGrouping.Isbn,
                        firstBookInGrouping.Title,
                        firstBookInGrouping.Author,
                        bookGrouping.Count(),
                        bookGrouping.Count(book => book.IsAvailable(loans))
                    );
                });
        }
    }
}