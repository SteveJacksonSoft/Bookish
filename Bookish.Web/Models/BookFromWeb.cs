using System;

namespace Bookish.Web.Models {
    public class BookFromWeb {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string NumCopiesOwned { get; set; }


        public int getNumCopies() {
            try {
                return int.Parse(NumCopiesOwned);
            } catch (FormatException) {
                Console.WriteLine("There was a problem adding the book: NumCopiesOwned is in the wrong format.");
            } catch (ArgumentNullException) {
                Console.WriteLine("There was a problem adding the book: NumCopiesOwned is null.");
            } catch (OverflowException) {
                Console.WriteLine("There was a problem adding the book: NumCopiesOwned is too big / small to fit into an int.");
            }

            return 0;
        }
    }
}