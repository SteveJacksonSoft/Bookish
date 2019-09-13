using System;
using System.Collections.Generic;
using System.Linq;
using Bookish.DataAccess;
using Bookish.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Web.Models {
    public class BooksPageModel {
        public BookListModel BookList { get; set; }
        public AddBookFormModel FormModel { get; set; }

        public BooksPageModel(IEnumerable<BookFromDB> bookList, IEnumerable<LoanFromDB> loanList) {
            BookList = new BookListModel(
                GenerateWebBookEnumerableFromDBRecords(bookList, loanList));
        }
        
        private static IEnumerable<BookForWeb> GenerateWebBookEnumerableFromDBRecords(
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

//        public class BookListModel {
//            public IEnumerable<BookForWeb> BooksList { get; set; }
//
//            public BookListModel(IEnumerable<BookForWeb> booksList) {
//                BooksList = booksList;
//            }
//        }
        
//        public class AddBookFormModel {
//            public string Isbn { get; set; }
//            public string Title { get; set; }
//            public string Author { get; set; }
//            public string NumCopiesOwned { get; set; }
//        }
    }
}