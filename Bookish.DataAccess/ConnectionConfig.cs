namespace Bookish.DataAccess {
    public class ConnectionConfig {
        public static string ConnectionString { get; } = @"Server=localhost;Database=Bookish;Trusted_Connection=True;";
    }
}