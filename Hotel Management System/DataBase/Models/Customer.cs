using ServiceStack.DataAnnotations;
using System;

namespace Hotel_Management_System.DataBase.Models
{
    [Alias("customers")]
    public class Customer
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }


        [Required, StringLength(41)]
        public string FullName { get; set; }


        [Required, StringLength(20)]
        public string Country { get; set; }


        [Required, StringLength(20), Unique]
        public string Passport { get; set; }


        [Required, StringLength(20), Unique]
        public string Phone { get; set; }


        [Required]
        public byte[] Photo { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
