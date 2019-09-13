using System.Collections.Generic;

namespace Bookish.Web.Models {
    public class BookListModel {
        public IEnumerable<BookForWeb> BooksList { get; set; }

        public BookListModel(IEnumerable<BookForWeb> booksList) {
            BooksList = booksList;
        }
    }
}