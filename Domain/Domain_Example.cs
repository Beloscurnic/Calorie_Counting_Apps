using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Domain_Example
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Last_Name { get; set; }

        public string First_Name { get; set; }

        public string Prace { get; set; }
        public string Children { get; set; }
    }

}
