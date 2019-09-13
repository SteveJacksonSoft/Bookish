using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;
using Bookish.DataAccess;
using Bookish.DataAccess.Models;
using Bookish.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookish.Web.Controllers {
    public class DataController : Controller {
        private readonly ILogger<DataController> _logger;
        private readonly DatabaseAccessObject _dao;

        public DataController(ILogger<DataController> logger) {
            _logger = logger;
            _dao = new DatabaseAccessObject();
        }

        [HttpPost]
        public IActionResult AddBook(AddBookFormModel bookData) {
            Console.WriteLine(
                $"Trying to add book: {bookData.Isbn} | {bookData.Title} | {bookData.Author} | {bookData.NumCopiesOwned}");

            List<Exception> exceptions = new List<Exception>();
            try {
                int numCopies = GetNumCopies(bookData.NumCopiesOwned);
                for (int bookNumber = 0; bookNumber < numCopies; bookNumber++) {
                    _dao.Add(new BookForDB(bookData.Isbn, bookData.Title, bookData.Author));
                }
            } catch (Exception e) {
                exceptions.Add(
                    new Exception(
                        "There was a problem adding the new book to the database: " + e.Message
                    )
                );
            }

            return View("Books", GenerateBooksPageModel(exceptions));
        }

        public IActionResult Books() {
            return View(GenerateBooksPageModel(new List<Exception>()));
        }
        
        private int GetNumCopies(string numCopiesOwned) {
            try {
                return int.Parse(numCopiesOwned);
            } catch (FormatException) {
                throw new Exception("NumCopiesOwned is in the wrong format.");
            } catch (ArgumentNullException) {
                throw new Exception("NumCopiesOwned was not given.");
            } catch (OverflowException) {
                throw new Exception("NumCopiesOwned is too big / small to fit into an int.");
            }
        }
        
        private BooksPageModel GenerateBooksPageModel(List<Exception>  exceptions) {
            List<LoanFromDB> loans = new List<LoanFromDB>();
            List<BookFromDB> books = new List<BookFromDB>();
            try {
                books.AddRange(_dao.GetAllBooks());
                loans.AddRange(_dao.GetAllLoans());
            } catch (Exception e) {
                exceptions.Add(e);
            }
            
            return new BooksPageModel(books, loans, exceptions);
        }
    }
}