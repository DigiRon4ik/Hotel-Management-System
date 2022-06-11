using ServiceStack.DataAnnotations;
using System;

namespace Hotel_Management_System.DataBase.Models
{
    [Alias("users")]    // Так будет называться таблица в БД
    public class User
    {   // Задаём первичный ключ и уникальный идентификатор
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        // Прописываем будущие колонки для таблицы
        [Required, StringLength(41)]
        public string FullName { get; set; }
        [Required, StringLength(20), Unique]
        public string Login { get; set; }
        [Required, StringLength(30)]
        public string Password { get; set; }
        [Required, StringLength(20), Unique]
        public string Phone { get; set; }
        [Required, StringLength(15)]
        public string Role { get; set; }
        // Массив байтов для хранения фотографий в БД
        [Required]
        public byte[] Photo { get; set; }
        // Поле, которое будет авто-заполняться
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
