using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Bookish.DataAccess.Models;
using Dapper;

namespace Bookish.DataAccess.DatabaseAccess {
    public class DatabaseAccessPractice {
        public static void Practice(string[] args) {
            IDbConnection Connection = new SqlConnection(ConnectionConfig.ConnectionString);
            IEnumerable<BookFromDB> books = Connection.Query<BookFromDB>("SELECT * FROM Books");

            foreach (BookFromDB book in books) {
                Console.WriteLine(book.Title);
            }
        }
    }
}