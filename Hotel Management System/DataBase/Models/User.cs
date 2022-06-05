using ServiceStack.DataAnnotations;
using System;

namespace Hotel_Management_System.DataBase.Models
{
    [Alias("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }


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


        [Required]
        public byte[] Photo { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
