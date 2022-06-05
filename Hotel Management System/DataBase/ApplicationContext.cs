using System.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Converters;
using Hotel_Management_System.DataBase.Models;

namespace Hotel_Management_System.DataBase
{
    public static class ApplicationContext
    {
        public static string connectionString = "Data Source=Data\\HMS.db; charset=utf8";
        public static byte[] defaultImage;

        public static IDbConnection GetDbConnection()
        {
            var dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
            StringConverter converter = OrmLiteConfig.DialectProvider.GetStringConverter();
            converter.UseUnicode = true;
            return dbFactory.Open();
        }

        public static void InitDB()
        {
            using (var db = GetDbConnection())
            {
                if (db.CreateTableIfNotExists<User>())
                {
                    db.Save(
                        new User {
                            FullName = "Тех. Поддержка",
                            Login = "Support",
                            Password = "support",
                            Role = "Support",
                            Phone = "8-(800)-555-35-35" },
                            //Photo = defaultImage },
                        new User {
                            FullName = "Абдулла Анхаев",
                            Login = "Abdul",
                            Password = "123",
                            Role = "Администратор",
                            Phone = "8-(928)-999-75-75" }
                            //Photo = defaultImage }
                    );
                }
            }
        }
    }
}
