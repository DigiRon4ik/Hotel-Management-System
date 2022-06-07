using System.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Converters;
using Hotel_Management_System.DataBase.Models;

namespace Hotel_Management_System.DataBase
{
    public static class ApplicationContext
    {
        public static string connectionString = "Data Source=Data\\HMS.db; charset=utf8";

        public static IDbConnection GetDbConnection()
        {
            var dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
            StringConverter converter = OrmLiteConfig.DialectProvider.GetStringConverter();
            converter.UseUnicode = true;
            return dbFactory.Open();
        }

        public static void InitDB(byte[] defaultImage)
        {
            using (var db = GetDbConnection())
            {
                if (db.CreateTableIfNotExists<User>())
                {
                    db.Save(
                        new User
                        {
                            FullName = "Тех. Поддержка",
                            Login = "Support",
                            Password = "support",
                            Role = "Support",
                            Phone = "8-(800)-555-35-35",
                            Photo = defaultImage
                        },
                        new User
                        {
                            FullName = "Абдулла Анхаев",
                            Login = "Abdul",
                            Password = "123",
                            Role = "Администратор",
                            Phone = "8-(928)-999-75-75",
                            Photo = defaultImage
                        }
                    );
                }

                if (db.CreateTableIfNotExists<Customer>())
                {
                    db.Save(
                        new Customer
                        {
                            FullName = "Максимов Анвар",
                            Country = "Россия",
                            Passport = "82 63 525632",
                            Phone = "8-(928)-646-72-27",
                            Photo = defaultImage
                        },
                        new Customer
                        {
                            FullName = "Mike K McIntosh",
                            Country = "США",
                            Passport = "984 722092",
                            Phone = "303-568-5660",
                            Photo = defaultImage
                        }
                    );
                }
            }
        }
    }
}
