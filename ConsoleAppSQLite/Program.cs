using SQLite;
using System;

namespace ConsoleAppSQLite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string databasePath = @"C:\Projects\Lab\SQLite\cipher.db";

            string[] maleNames = new string[10] { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian"};
            string[] lastNames = new string[5] { "abbott", "acosta", "adams", "adkins", "aguilar"};
            Random r = new Random();

            var options = new SQLiteConnectionString(databasePath, true, key: "Nokia1234");
            var connection = new SQLiteConnection(options);
            connection.Execute($"INSERT INTO Users(FName, LName) VALUES('{maleNames[r.Next(0, 9)]}','{lastNames[r.Next(0, 4)]}')");

            var users = connection.Query<User>("SELECT * FROM Users");

            foreach(User user in users)
            { 
                Console.WriteLine($"{user.ID} , FIRST NAME: {user.FName} LAST NAME: {user.LName}");
            }

            connection.Close();

            Console.ReadKey();
        }

        public class User
        {
            public int ID { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
        }
    }
}
