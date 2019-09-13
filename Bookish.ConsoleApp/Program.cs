using System;
using System.Configuration;
using Bookish.DataAccess.DatabaseAccess;


namespace Bookish.ConsoleApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Console.WriteLine(ConfigurationManager.ConnectionStrings["TestString"].ConnectionString);
        }
    }
}