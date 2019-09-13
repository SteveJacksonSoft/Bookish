namespace Bookish.DataAccess.Models {
    public class UserForDB {
        public UserForDB(string userName) {
            UserName = userName;
        }
        public string UserName { get; }
    }
}