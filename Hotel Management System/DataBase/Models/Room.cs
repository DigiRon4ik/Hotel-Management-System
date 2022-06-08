using ServiceStack.DataAnnotations;
using Hotel_Management_System.DataBase.Models;
using System;

namespace Hotel_Management_System.DataBase.Models
{
    [Alias("rooms")]
    public class Room
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }


        [Required, Default(0)]
        public bool isFree { get; set; }


        [Required, ForeignKey(typeof(Category), OnDelete = "CASCADE"), Default(0)]
        public int CategoryId { get; set; }


        [Required, Unique]
        public int Number { get; set; }

        
        [ForeignKey(typeof(Customer), OnDelete = "CASCADE"), Default(0)]
        public int CustomerId { get; set; }


        [Required]
        public int Price { get; set; }


        public DateTime From { get; set; }
        public DateTime Until { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
