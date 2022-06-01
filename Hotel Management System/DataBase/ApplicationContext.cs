using System.Data;
using ServiceStack.OrmLite;
using Hotel_Management_System.DataBase.Models;

namespace Hotel_Management_System.DataBase
{
    internal class ApplicationContext
    {
        public static string connectionString = "Data\\HMS.db";
        
        public static IDbConnection GetDbConnection()
        {
            var dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
            return dbFactory.Open();
        }

        public static void InitDB()
        {
            using (var db = GetDbConnection())
            {
                if (db.CreateTableIfNotExists<User>())
                {
                    db.Save(new User { Login = "Support", Password = "support", Role = "Support", Name = "Тех.", Surname = "Поддержка", Phone = "8-(800)-555-35-35" });
                    db.Save(new User { Login = "Abdul", Password = "123", Role = "Администратор", Name = "Абдулла", Surname = "Анхаев", Phone = "8-(928)-999-75-75" });
                }
            }
        }
    }
}
