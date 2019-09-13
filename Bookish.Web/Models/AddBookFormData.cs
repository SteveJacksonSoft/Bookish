namespace Bookish.Web.Models {
    public class AddBookFormModel {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string NumCopiesOwned { get; set; }
    }
}