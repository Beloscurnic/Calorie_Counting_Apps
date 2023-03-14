using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CalorieIntake
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }
    }
}
