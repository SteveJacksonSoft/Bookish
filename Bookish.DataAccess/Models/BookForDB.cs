namespace Bookish.DataAccess.Models {
    public class BookForDB {
        public string Isbn;
        public string Title;
        public string Author;
        
        public BookForDB() { }

        public BookForDB(string isbn, string title, string author) {
            Isbn = isbn;
            Title = title;
            Author = author;
        }
    }
}