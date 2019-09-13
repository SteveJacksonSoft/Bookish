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
        public BookExceptionList ExceptionList { get; set; }

        public BooksPageModel(IEnumerable<BookFromDB> bookList, IEnumerable<LoanFromDB> loanList,
            IEnumerable<Exception> exceptions) {
            BookList = new BookListModel(
                GenerateWebBookEnumerableFromDBRecords(bookList, loanList));

            ExceptionList = new BookExceptionList(exceptions);
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
    }
}