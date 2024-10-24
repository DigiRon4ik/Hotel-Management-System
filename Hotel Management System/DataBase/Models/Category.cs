﻿using ServiceStack.DataAnnotations;
using System;

namespace Hotel_Management_System.DataBase.Models
{
    [Alias("categories")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }


        [Required, StringLength(15), Unique]
        public string Title { get; set; }


        [Required, Default(1)]
        public int CountRooms { get; set; }
        [Required, Default(1)]
        public int ForPeople { get; set; }


        [Required, Default(0)]
        public bool isWIFI { get; set; }
        [Required, Default(0)]
        public bool isTV { get; set; }


        [StringLength(500)]
        public string Description { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
