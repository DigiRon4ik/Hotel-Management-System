using System.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Converters;
using Hotel_Management_System.DataBase.Models;
using System;

namespace Hotel_Management_System.DataBase
{
    public static class ApplicationContext
    {
        public static string connectionString = "DataBase\\HMS.db";

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
                        });
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
                        });
                }

                if (db.CreateTableIfNotExists<Category>())
                {
                    db.Save(
                        new Category
                        {
                            Title = "Переночёвка",
                            CountRooms = 1,
                            ForPeople = 1,
                            isWIFI = false,
                            isTV = false,
                            Description = "Простая комната для быстрой переночёвки пару дней."
                        },
                        new Category
                        {
                            Title = "Эконом",
                            CountRooms = 1,
                            ForPeople = 1,
                            isWIFI = true,
                            isTV = false,
                            Description = "Номера эконом-класса на пару дней."
                        },
                        new Category
                        {
                            Title = "Бизнес",
                            CountRooms = 3,
                            ForPeople = 4,
                            isWIFI = true,
                            isTV = true,
                            Description = "Бизнес-Класс для деловых людей."
                        },
                        new Category
                        {
                            Title = "Пара",
                            CountRooms = 1,
                            ForPeople = 2,
                            isWIFI = true,
                            isTV = true,
                            Description = "Номера для молодых влюблённых."
                        },
                        new Category
                        {
                            Title = "Пати",
                            CountRooms = 2,
                            ForPeople = 4,
                            isWIFI = true,
                            isTV = false,
                            Description = "Эти номера предназначены для групп туристов из 4-х и меньше человек."
                        });
                }

                if (db.CreateTableIfNotExists<Room>())
                {
                    db.Save(
                        new Room
                        {
                            isFree = false,
                            CategoryId = 3,
                            Number = 303,
                            CustomerId = 2,
                            Price = 15000,
                            From = DateTime.Now,
                            Until = DateTime.Now.AddDays(5)
                        },
                        new Room
                        {
                            isFree = true,
                            CategoryId = 1,
                            Number = 301,
                            Price = 3000
                        });
                }

                if (db.CreateTableIfNotExists<Salary>())
                    db.Save(new Salary { salary = 15000 * 5 });
            }
        }
    }
}
