using System;
using System.Collections.Generic;
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
            int numCopies = GetNumCopies(bookData.NumCopiesOwned);

            for (int bookNumber = 0; bookNumber < numCopies; bookNumber++) {
                _dao.Add(new BookForDB(bookData.Isbn, bookData.Title, bookData.Author));
            }

            return View("Books", GenerateBooksPageModel());
        }

        public IActionResult Books() {
            return View(GenerateBooksPageModel());
        }

        private BooksPageModel GenerateBooksPageModel() {
            return new BooksPageModel(_dao.GetAllBooks(), _dao.GetAllLoans());
        }
        
        private int GetNumCopies(string numCopiesOwned) {
            try {
                return int.Parse(numCopiesOwned);
            } catch (FormatException) {
                Console.WriteLine("There was a problem adding the book: NumCopiesOwned is in the wrong format.");
            } catch (ArgumentNullException) {
                Console.WriteLine("There was a problem adding the book: NumCopiesOwned is null.");
            } catch (OverflowException) {
                Console.WriteLine(
                    "There was a problem adding the book: NumCopiesOwned is too big / small to fit into an int.");
            }

            return 0;
        }
    }
}