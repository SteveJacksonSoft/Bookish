using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Bookish.DataAccess.Models;
using Dapper;

namespace Bookish.DataAccess {
    public class DatabaseAccessObject {
        private readonly string _connectionString;

        public DatabaseAccessObject() {
            string con = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            _connectionString = ConnectionConfig.ConnectionString;
        }

        public IEnumerable<BookFromDB> GetAllBooks() {
            using (var connection = new SqlConnection(_connectionString)) {
                return connection.Query<BookFromDB>("SELECT * FROM Books");
            }
        }
        
        public IEnumerable<BookFromDB> GetBooksByIsbn(int isbn) {
            using (var connection = new SqlConnection(_connectionString)) {
                return connection.Query<BookFromDB>("SELECT * FROM Books WHERE Isbn=@isbn", new {isbn});
            }
        }

        public IEnumerable<BookFromDB> GetBookById(int id) {
            using (var connection = new SqlConnection(_connectionString)) {
                return connection.Query<BookFromDB>("SELECT * FROM Books WHERE Id=@id", new {id});
            }
        }

        public IEnumerable<BookFromDB> GetBooksByAuthor(string author) {
            using (var connection = new SqlConnection(_connectionString)) {
                return connection.Query<BookFromDB>(
                    "SELECT * FROM Books WHERE Author=@author",
                    new {author}
                );
            }
        }

        public IEnumerable<LoanFromDB> GetAllLoans() {
            using (var connection = new SqlConnection(_connectionString)) {
                return connection.Query<LoanFromDB>("SELECT * FROM Loans");
            }
        }

        public int Add(BookForDB book) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Query(
                    "INSERT INTO Books VALUES (@isbn, @title, @author)",
                    new {
                        isbn = book.Isbn,
                        title = book.Title,
                        author = book.Author
                    });
                IEnumerable<int> bookIds = connection.Query<int>("SELECT Id FROM Books");
                return bookIds.Last();
            }
        }

        public int Add(UserForDB user) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Query("INSERT INTO Users VALUES (@userName)", new {userName = user.UserName});
                IEnumerable<int> userIds = connection.Query<int>("SELECT Id FROM Users");
                return userIds.Last();
            }
        }

        public int Add(LoanForDB loan) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Query(
                    "INSERT INTO Loans VALUES (@bookId, @borrowerId, @dateBorrowed, @dateDue, @returned)",
                    new {
                        bookId = loan.BookId,
                        borrowerId = loan.BorrowerId,
                        dateBorrowed = loan.DateBorrowed,
                        dateDue = loan.DateDue,
                        returned = loan.Returned
                    });
                IEnumerable<int> loanIds = connection.Query<int>("SELECT Id FROM Loans");
                return loanIds.Last();
            }
        }
    }
}