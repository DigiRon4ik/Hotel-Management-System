using ServiceStack.DataAnnotations;
using System;

namespace Hotel_Management_System.DataBase.Models
{
    [Alias("categories")]
    internal class Category
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }


        [Required, StringLength(15), Unique]
        public string Title { get; set; }


        [Required]
        public int CountRooms { get; set; }
        [Required]
        public int ForPeople { get; set; }


        [Required, Default(0)]
        public bool isWIFI { get; set; }
        [Required, Default(0)]
        public bool isTV { get; set; }


        public string Discription { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
