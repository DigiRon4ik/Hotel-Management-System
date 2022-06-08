using ServiceStack.DataAnnotations;
using System;

namespace Hotel_Management_System.DataBase.Models
{
    [Alias("salaries")]
    public class Salary
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [Unique]
        public int salary { get; set; }

        public DateTime CreatedAt = DateTime.Now;
    }
}
